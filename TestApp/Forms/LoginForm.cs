using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.EventHandler;
using TestApp.Model;
using System.Configuration;


namespace TestApp.Forms
{
    public partial class LoginForm : Form
    {

        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "Логин или пароль пустые";
                lblError.Show();
                return;
            }
            if (txtUsername.Text == "admin")
            {
                SQLiteConnection conn = new SQLiteConnection();
                try
                {
                    conn = new SQLiteConnection(strConnect);
                    conn.Open();
                    SQLiteCommand CMD = conn.CreateCommand();
                    CMD.CommandText = "SELECT password FROM LoginTable WHERE username = @username";
                    CMD.Parameters.Add("@username", System.Data.DbType.String).Value = txtUsername.Text;
                    SQLiteDataReader SQL = CMD.ExecuteReader();
                    if (SQL.HasRows)
                    {
                        while (SQL.Read())
                        {
                            if (SQL["password"].ToString() != txtPassword.Text)
                            {
                                lblError.Text = "Неправильный пароль";
                            }
                        }
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
                AdminProfileForm adminProfileForm = new AdminProfileForm();
                adminProfileForm.Show();
                this.Hide();
            }
            else
            {
                string error = UserHandler.CheckUser(txtUsername.Text, txtPassword.Text);
                if (error == "ОК")
                {
                    Worker user = UserHandler.GetUser(txtUsername.Text);
                    UserProfileForm userProfileForm = new UserProfileForm(user);
                    userProfileForm.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Text = error;
                }
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Worker user = UserHandler.GetUser(txtUsername.Text);
            if (user.Name != null || txtUsername.Text == "admin")
            {
                lblError.Text = "Пользователь уже существует";
                lblError.Show();
            }
            else
            {
                this.Hide();
                
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is RegisterForm)
                    {
                        frm.Show();
                        return;
                    }
                }
                RegisterForm register = new RegisterForm(txtUsername.Text, txtPassword.Text);
                register.Show();
             
            }
            
        }

    }
}
