using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using TestApp.Model;
using System.Data.SQLite;
using System.Data;

namespace TestApp.EventHandler
{
    public static class UserHandler
    {
        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        public static Worker UserCreated(Dictionary<string, string> parameters, DateTime date)
        {
            Worker user = new Worker();

            user.Username = parameters["username"];
            user.Name = parameters["name"];
            user.Surname = parameters["surname"];
            user.Date = date;
            user.Position = parameters["role"];

            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "INSERT INTO LoginTable(username, password) VALUES(@username, @password)";
                CMD.Parameters.Add("@username", System.Data.DbType.String).Value = parameters["username"];
                CMD.Parameters.Add("@password", System.Data.DbType.String).Value = parameters["password"];

                CMD.ExecuteNonQuery();


                CMD.CommandText = "SELECT id FROM LoginTable WHERE username = @username";
                CMD.Parameters.Add("@username", System.Data.DbType.String).Value = parameters["username"];

                SQLiteDataReader SQL = CMD.ExecuteReader();


                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        user.UserID = Convert.ToInt16(SQL["id"]);
                    }
                }

                SQL.Close();


                CMD.CommandText = "SELECT baseSalary, coeffDate, maxDate FROM RoleTable WHERE role = @role";
                CMD.Parameters.Add("@role", System.Data.DbType.String).Value = parameters["role"];

                SQL = CMD.ExecuteReader();

                int baseSalary = 0;
                int coeff = 0;
                int maxDate = 0;

                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        baseSalary = Convert.ToInt32(SQL["baseSalary"].ToString());
                        coeff = Convert.ToInt32(SQL["coeffDate"].ToString());
                        maxDate = Convert.ToInt32(SQL["maxDate"].ToString());
                    }
                }
                else
                {

                }

                SQL.Close();


                CMD.CommandText = "INSERT INTO PersonalInfoTable(id, name, surname, date, roleID)" +
                    " VALUES(@id, @name, @surname, @date, (SELECT roleID from RoleTable WHERE role = @role))";

                CMD.Parameters.Add("@id", System.Data.DbType.Int16).Value = user.UserID;
                CMD.Parameters.Add("@name", System.Data.DbType.String).Value = parameters["name"];
                CMD.Parameters.Add("@surname", System.Data.DbType.String).Value = parameters["surname"];
                CMD.Parameters.Add("@date", System.Data.DbType.Date).Value = date;
                CMD.Parameters.Add("@role", System.Data.DbType.String).Value = parameters["role"];



                CMD.ExecuteNonQuery();

                var now = DateTime.Now;
                var timeOfWork = now.Subtract(date);
                int totalPercent = (Convert.ToInt32(timeOfWork.TotalDays) / 365) * coeff;

                if (totalPercent >= maxDate)
                {
                    totalPercent = maxDate;
                }

                int Salary = ((baseSalary / 100) * totalPercent) + baseSalary;

                CMD.CommandText = "INSERT INTO SalaryTable(userID, salary) VALUES(@userID, @Salary)";
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = user.UserID;
                CMD.Parameters.Add("@salary", System.Data.DbType.Int16).Value = Salary;
                CMD.ExecuteNonQuery();

                CMD.CommandText = "INSERT INTO SurchargeTable(userID, surcharge) VALUES(@userID, @surcharge)";
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = user.UserID;
                CMD.Parameters.Add("@surcharge", System.Data.DbType.Int16).Value = 0;
                CMD.ExecuteNonQuery();

                user.Salary = Salary;
                user.Surcharge = 0;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public static Worker GetUser(string username)
        {
            Worker user = new Worker();

            SQLiteConnection conn = new SQLiteConnection();

            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT id, name, surname, date, role, salary ,surcharge FROM PersonalInfoTable p" +
                    " INNER JOIN SalaryTable s ON p.id = s.userID" +
                    " INNER JOIN SurchargeTable sc ON p.id = sc.userID" +
                    " INNER JOIN RoleTable r ON p.roleID = r.roleID" +
                    " WHERE(id IN (SELECT id FROM LoginTable WHERE username = @username))";
                CMD.Parameters.Add("@username", System.Data.DbType.String).Value = username;

                SQLiteDataReader SQL = CMD.ExecuteReader();

                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        user.UserID = Convert.ToInt16(SQL["id"]);
                        user.Username = username;
                        user.Name = SQL["name"].ToString();
                        user.Surname = SQL["surname"].ToString();
                        user.Position = SQL["role"].ToString();
                        user.Date = Convert.ToDateTime(SQL["date"]);
                        user.Salary = Convert.ToInt32(SQL["salary"].ToString());
                        user.Surcharge = Convert.ToDouble(SQL["surcharge"].ToString());
                    }
                }
                else
                {
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

            return user;
        }

        public static void AddSubordinate(Worker Head, Worker User)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "INSERT INTO HeadTable(headID, workerID) VALUES(@headID, @userID)";
                CMD.Parameters.Add("@headID", System.Data.DbType.Int16).Value = Head.UserID;
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = User.UserID;
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
            SalaryHandler.ChangeSurcharge(Head, true);
        }

        public static void DeleteSubordinate(Worker Head, Worker User)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "DELETE FROM HeadTable WHERE headID = @headID AND workerID = @userID";
                CMD.Parameters.Add("@headID", System.Data.DbType.Int16).Value = Head.UserID;
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = User.UserID;
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
            SalaryHandler.ChangeSurcharge(Head, true);

        }

        public static DataTable GetListWorkers()
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT * FROM PersonalInfoTable WHERE id NOT IN (SELECT workerID FROM HeadTable)";
                SQLiteDataReader dr = CMD.ExecuteReader();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public static string CheckUser(string username, string password)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT * FROM LoginTable WHERE username = @username AND password = @password";
                CMD.Parameters.Add("@username", System.Data.DbType.String).Value = username;
                CMD.Parameters.Add("@password", System.Data.DbType.String).Value = password;
                SQLiteDataReader SQL = CMD.ExecuteReader();
                if (SQL.HasRows)
                {
                    return "ОК";
                }
                else
                {
                    return "Неправильный логин или пароль";
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
    }
}
