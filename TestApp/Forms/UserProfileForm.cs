using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using TestApp.Model;
using TestApp.EventHandler;
using System.Data.SQLite;

namespace TestApp.Forms
{
    public partial class UserProfileForm : Form
    {
        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        private Worker User;

        

        public UserProfileForm(Worker user)
        {
            User = user;
            InitializeComponent();
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            if (User.Position == "Employee")
            {
                boxMid.Visible = false;
            }
            lblName.Text += User.Name.ToString();
            lblSurname.Text += User.Surname.ToString();
            lblDate.Text += User.Date.ToShortDateString().ToString(); 
            lblSalary.Text = "Зарплата: "+(Convert.ToDouble(User.Salary) + User.Surcharge).ToString();
            boxBot.Visible = false;
            btnAddConfirm.Visible = false;
            btnRemoveConfirm.Visible = false;
            lblConfirm.Visible = false;

        }

        private void UserProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            ShowListForLook();
            boxBot.Visible = true;
            btnAddConfirm.Visible = false;
            btnRemoveConfirm.Visible = false;
            lblConfirm.Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowListForAdd();
            boxBot.Visible = true;
            btnAddConfirm.Visible = true;
            btnRemoveConfirm.Visible = false;
            lblConfirm.Visible = true;
            lblConfirm.Text = "Подтвердите добавление";

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ShowListForRemove();
            boxBot.Visible = true;
            btnRemoveConfirm.Visible = true;
            btnAddConfirm.Visible = false;
            lblConfirm.Visible = true;
            lblConfirm.Text = "Подтвердите удаление";

        }

        private void btnRemoveConfirm_Click(object sender, EventArgs e)
        {
            if (listWorkers.SelectedItems.Count == 1)
            {

                String text = listWorkers.SelectedItems[0].Text;
                Worker worker = UserHandler.GetUser(text);
                UserHandler.DeleteSubordinate(User, worker);
                ShowListForRemove();
                User = UserHandler.GetUser(User.Username);
                lblSalary.Text = "Зарплата: " + (Convert.ToDouble(User.Salary) + User.Surcharge).ToString();
            }
            else
            {
                lblConfirm.Text = "Выберите одного работника";
            }
        }

        private void btnAddConfirm_Click(object sender, EventArgs e)
        {
            if (listWorkers.SelectedItems.Count == 1)
            {
                String text = listWorkers.SelectedItems[0].Text;
                Worker worker = UserHandler.GetUser(text);
                lblSalary.Text = User.Name + text;
                UserHandler.AddSubordinate(User, worker);
                ShowListForAdd();
                User = UserHandler.GetUser(User.Username);
                lblSalary.Text = "Зарплата: " + (Convert.ToDouble(User.Salary) + User.Surcharge).ToString();
            }
            else
            {
                lblConfirm.Text = "Выберите одного работника";
            }
        }


        private void ShowListForAdd()
        {
            listWorkers.Columns[listWorkers.Columns.Count - 1].Width = 0;
            listWorkers.Items.Clear();
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT l.username, p.name, p.surname, p.date, r.role FROM PersonalInfoTable p" +
                    " INNER JOIN LoginTable l ON p.id = l.id" +
                    " INNER JOIN RoleTable r ON  p.roleID = r.roleID" +
                    " WHERE(p.id NOT IN (SELECT workerID FROM HeadTable WHERE headID = @headID) AND p.id != @headID)";
                CMD.Parameters.Add("@headID", System.Data.DbType.Int16).Value = User.UserID;
                SQLiteDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["username"].ToString());
                    item.SubItems.Add(dr["name"].ToString());
                    item.SubItems.Add(dr["surname"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(dr["date"]).ToShortDateString());
                    item.SubItems.Add(dr["role"].ToString());
                    item.SubItems.Add(dr["role"].ToString());
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

        private void ShowListForRemove()
        {
            listWorkers.Items.Clear();
            listWorkers.Columns[listWorkers.Columns.Count - 1].Width = 0;
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT l.username, p.name, p.surname, p.date, r.role FROM PersonalInfoTable p" +
                    " INNER JOIN LoginTable l ON p.id = l.id" +
                    " INNER JOIN RoleTable r ON  p.roleID = r.roleID" +
                    " WHERE(p.id IN (SELECT workerID FROM HeadTable WHERE headID = @headID))";
                CMD.Parameters.Add("@headID", System.Data.DbType.Int16).Value = User.UserID;
                SQLiteDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["username"].ToString());
                    item.SubItems.Add(dr["name"].ToString());
                    item.SubItems.Add(dr["surname"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(dr["date"]).ToShortDateString());
                    item.SubItems.Add(dr["role"].ToString());
                    item.SubItems.Add(dr["role"].ToString());
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

        private void ShowListForLook()
        {
            listWorkers.Items.Clear();
            listWorkers.Columns[listWorkers.Columns.Count - 1].Width = 116;
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT l.username, p.name, p.surname, p.date, r.role, s.salary,sc.surcharge FROM PersonalInfoTable p" +
                    " INNER JOIN LoginTable l ON p.id = l.id" +
                    " INNER JOIN RoleTable r ON  p.roleID = r.roleID" +
                    " INNER JOIN SalaryTable s ON p.id = s.userID" +
                    " INNER JOIN SurchargeTable sc ON p.id = sc.userID" +
                    " WHERE(p.id IN (SELECT workerID FROM HeadTable WHERE headID = @headID))";
                CMD.Parameters.Add("@headID", System.Data.DbType.Int16).Value = User.UserID;
                SQLiteDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["username"].ToString());
                    item.SubItems.Add(dr["name"].ToString());
                    item.SubItems.Add(dr["surname"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(dr["date"]).ToShortDateString());
                    item.SubItems.Add(dr["role"].ToString());
                    item.SubItems.Add((Convert.ToInt16(dr["salary"]) + Convert.ToInt16(dr["surcharge"])).ToString());
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

        private void boxUp_Enter(object sender, EventArgs e)
        {

        }
    }
}
