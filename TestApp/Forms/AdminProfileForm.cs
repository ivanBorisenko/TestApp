using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;
using TestApp.EventHandler;

namespace TestApp.Forms
{
    public partial class AdminProfileForm : Form
    {
        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        public AdminProfileForm()
        {
            InitializeComponent();
        }

        private void AdminProfileForm_Load(object sender, EventArgs e)
        {
            groupBoxMid.Visible = false;
            ShowListOfAllUsers();
        }

        private void ShowListOfAllUsers()
        {
            listWorkers.Items.Clear();
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT l.id,l.username,l.password, p.name, p.surname, p.date, r.role, s.salary, sc.surcharge FROM PersonalInfoTable p" +
                    " INNER JOIN LoginTable l ON p.id = l.id" +
                    " INNER JOIN RoleTable r ON  p.roleID = r.roleID" +
                    " INNER JOIN SalaryTable s ON p.id = s.userID" +
                    " INNER JOIN SurchargeTable sc ON p.id = sc.userID";
                SQLiteDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["id"].ToString());
                    item.SubItems.Add(dr["username"].ToString());
                    item.SubItems.Add(dr["password"].ToString());
                    item.SubItems.Add(dr["name"].ToString());
                    item.SubItems.Add(dr["surname"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(dr["date"]).ToShortDateString());
                    item.SubItems.Add(dr["role"].ToString());
                    item.SubItems.Add(dr["salary"].ToString());
                    item.SubItems.Add(dr["surcharge"].ToString());
                    listWorkers.Items.Add(item);
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

        private void ShowListSubordinate()
        {
            groupBoxMid.Visible = true;
            listSub.Items.Clear();
            int userID = Convert.ToInt16(listWorkers.SelectedItems[0].Text);
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT l.id,l.username,l.password, p.name, p.surname, p.date, r.role, s.salary, sc.surcharge FROM PersonalInfoTable p" +
                    " INNER JOIN LoginTable l ON p.id = l.id" +
                    " INNER JOIN RoleTable r ON  p.roleID = r.roleID" +
                    " INNER JOIN SalaryTable s ON p.id = s.userID" +
                    " INNER JOIN SurchargeTable sc ON p.id = sc.userID" +
                    " WHERE(p.id IN (SELECT workerID FROM HeadTable WHERE headID = @userID))";
                CMD.Parameters.Add("@userID", System.Data.DbType.Int16).Value = userID;
                SQLiteDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["id"].ToString());
                    item.SubItems.Add(dr["username"].ToString());
                    item.SubItems.Add(dr["password"].ToString());
                    item.SubItems.Add(dr["name"].ToString());
                    item.SubItems.Add(dr["surname"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(dr["date"]).ToShortDateString());
                    item.SubItems.Add(dr["role"].ToString());
                    item.SubItems.Add(dr["salary"].ToString());
                    item.SubItems.Add(dr["surcharge"].ToString());
                    listSub.Items.Add(item);
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

        private void DeleteUser()
        {
            int userID = Convert.ToInt16(listWorkers.SelectedItems[0].Text);
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();
                SQLiteCommand CMD = conn.CreateCommand();
                CMD.CommandText = "DELETE FROM LoginTable WHERE id = @id";
                CMD.Parameters.AddWithValue("@id", userID);
                CMD.ExecuteNonQuery();
                CMD.CommandText = "DELETE FROM PersonalInfoTable WHERE id = @id";
                CMD.Parameters.AddWithValue("@id", userID);
                CMD.ExecuteNonQuery();
                CMD.CommandText = "DELETE FROM SalaryTable WHERE userID = @id";
                CMD.Parameters.AddWithValue("@id", userID);
                CMD.ExecuteNonQuery();
                CMD.CommandText = "DELETE FROM SurchargeTable WHERE userID = @id";
                CMD.Parameters.AddWithValue("@id", userID);
                CMD.ExecuteNonQuery();
                CMD.CommandText = "DELETE FROM HeadTable WHERE workerID = @id";
                CMD.Parameters.AddWithValue("@id", userID);
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
            ShowListOfAllUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            if (listWorkers.SelectedItems.Count > 0)
            {
                lblError.Text = "";
                ShowListSubordinate();
            }
            else
            {
                lblError.Text = "Выберите пользователя";
            }
        }

        private void btnChangeSalary_Click(object sender, EventArgs e)
        {
            BaseSalaryForm baseSalaryForm = new BaseSalaryForm();
            baseSalaryForm.Show();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();
                CMD.CommandText = "SELECT p.id, username, date, baseSalary, coeffDate, maxDate FROM LoginTable l" +
                    " INNER JOIN PersonalInfoTable p ON l.id = p.id" +
                    " INNER JOIN RoleTable r ON p.roleID = r.roleID";
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
            SalaryHandler.changeDateSalary(dt);
            SalaryHandler.ChangeSurchargeForAll(dt);
            ShowListOfAllUsers();
        }

        private void AdminProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
