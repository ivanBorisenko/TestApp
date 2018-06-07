using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using TestApp.Model;

namespace TestApp.EventHandler
{
    public static class SalaryHandler
    {
        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        public static void ChangeSurcharge(Worker head, bool flag)
        {

            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();
                double sum = 0;
                SQLiteCommand CMD = conn.CreateCommand();
                if (flag == true || head.Position != "Manager")
                {
                    if (head.Position == "Manager")
                    {
                        sum = SumManagerSurcharge(head, 0);
                    }
                    else
                    {
                        sum = SumSalesmanSurcharge(head, 0, true);
                    }
                    //int sum = 0;
                    double coeffSur = 0;

                    CMD.CommandText = "SELECT coeffSur FROM RoleTable WHERE role = @role";
                    CMD.Parameters.Add("@role", System.Data.DbType.String).Value = head.Position;
                    SQLiteDataReader SQL = CMD.ExecuteReader();
                    if (SQL.HasRows)
                    {
                        while (SQL.Read())
                        {
                            coeffSur = Convert.ToDouble(SQL["coeffSur"]);
                        }

                    }
                    else
                    {

                    }
                    SQL.Close();

                    double surcharge = ((sum / 100) * coeffSur);
                   
                    CMD.CommandText = "UPDATE SurchargeTable SET surcharge = @surcharge WHERE userID = @userID";
                    CMD.Parameters.Add("@surcharge", System.Data.DbType.Double).Value = Math.Round(surcharge,2);
                    CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = head.UserID;
                    CMD.ExecuteNonQuery();
                }

                CMD.CommandText = "SELECT username FROM LoginTable WHERE id IN (SELECT headID FROM HeadTable WHERE workerID = @userID)";
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = head.UserID;

                SQLiteDataReader SQLR = CMD.ExecuteReader();
                //SQLiteDataReader SQL = CMD.ExecuteReader();
                string newHeadUsername = null;

                if (SQLR.HasRows)
                {
                    while (SQLR.Read())
                    {
                        newHeadUsername = SQLR["username"].ToString();
                    }
                    Worker newHead = UserHandler.GetUser(newHeadUsername);
                    ChangeSurcharge(newHead, false);
                    SQLR.Close();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public static double SumSalesmanSurcharge(Worker user, double sum, bool flag)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();
                SQLiteCommand CMD = conn.CreateCommand();
                if (flag == false)
                {
                    CMD.CommandText = "SELECT salary FROM SalaryTable WHERE userID = @userID";
                    CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = user.UserID;
                    SQLiteDataReader SQLR = CMD.ExecuteReader();
                    if (SQLR.HasRows)
                    {
                        while (SQLR.Read())
                        {
                            sum += Convert.ToDouble(SQLR["salary"]);
                        }
                    }
                    SQLR.Close();
                    CMD.CommandText = "SELECT surcharge FROM SurchargeTable WHERE userID = @userID";
                    CMD.Parameters.Add("@userID", System.Data.DbType.Double).Value = user.UserID;
                    SQLR = CMD.ExecuteReader();
                    if (SQLR.HasRows)
                    {
                        while (SQLR.Read())
                        {
                            sum += Convert.ToDouble(SQLR["surcharge"]);
                        }
                    }
                    SQLR.Close();

                }

                CMD.CommandText = "SELECT username FROM LoginTable WHERE id IN (SELECT workerID FROM HeadTable WHERE headID = @userID)";
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = user.UserID;

                SQLiteDataReader SQL = CMD.ExecuteReader();
                string newUsername = null;

                if (SQL.HasRows)
                {
                    flag = false;
                    while (SQL.Read())
                    {
                        newUsername = SQL["username"].ToString();
                        Worker newUser = UserHandler.GetUser(newUsername);
                        sum = SumSalesmanSurcharge(newUser, sum, flag);
                    }
                }
                SQL.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return sum;
        }

        public static double SumManagerSurcharge(Worker user, double sum)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();
                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT workerID FROM HeadTable WHERE headID = @userID";
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = user.UserID;

                SQLiteDataReader SQL = CMD.ExecuteReader();

                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        SQLiteCommand CMDR = conn.CreateCommand();
                        CMDR.CommandText = "SELECT salary FROM SalaryTable WHERE userID = @userID";
                        CMDR.Parameters.Add("@userID", System.Data.DbType.Int16).Value = Convert.ToInt16(SQL["workerID"]);
                        SQLiteDataReader SQLR = CMDR.ExecuteReader();
                        if (SQLR.HasRows)
                        {
                            while (SQLR.Read())
                            {
                                sum += Convert.ToDouble(SQLR["salary"]);
                            }
                        }
                        SQLR.Close();

                        CMDR.CommandText = "SELECT surcharge FROM SurchargeTable WHERE userID = @userID";
                        CMDR.Parameters.Add("@userID", System.Data.DbType.Double).Value = Convert.ToInt16(SQL["workerID"]);
                        SQLR = CMDR.ExecuteReader();
                        if (SQLR.HasRows)
                        {
                            while (SQLR.Read())
                            {
                                sum += Convert.ToDouble(SQLR["surcharge"]);
                            }
                        }
                        SQLR.Close();
                    }
                }
                SQL.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return sum;
        }

        public static void changeDateSalary(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                SQLiteConnection conn = new SQLiteConnection();
                try
                {
                    conn = new SQLiteConnection(strConnect);
                    conn.Open();

                    SQLiteCommand CMD = conn.CreateCommand();
                    int id = Convert.ToInt16(dr["id"]);
                    DateTime date = Convert.ToDateTime(dr["date"]);
                    int baseSalary = Convert.ToInt16(dr["baseSalary"]);
                    int coeffDate = Convert.ToInt16(dr["coeffDate"]);
                    int maxDate = Convert.ToInt16(dr["maxDate"]);
                    var now = DateTime.Now;
                    var timeOfWork = now.Subtract(date);
                    int totalPercent = (Convert.ToInt32(timeOfWork.TotalDays) / 365) * coeffDate;

                    if (totalPercent >= maxDate)
                    {
                        totalPercent = maxDate;
                    }

                    int Salary = ((baseSalary / 100) * totalPercent) + baseSalary;
                    CMD.CommandText = "UPDATE SalaryTable  SET salary = @salary WHERE userID = @userID";
                    CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = id;
                    CMD.Parameters.Add("@salary", System.Data.DbType.Int16).Value = Salary;
                    CMD.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void ChangeSurchargeForAll(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string username = dr["username"].ToString();
                Worker user = UserHandler.GetUser(username);
                ChangeSurcharge(user, true);
            }
        }

    }
}
