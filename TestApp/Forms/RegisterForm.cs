using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp.Model;
using TestApp.EventHandler;

namespace TestApp.Forms
{
    public partial class RegisterForm : Form
    {

        private string username;
        private string password;

  

        public RegisterForm(string Username, string Password)
        {
          
            username = Username;
            password = Password;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            foreach (Form frm in Application.OpenForms)
            {
                if (frm is LoginForm)
                {
                    frm.Show();
                    return;
                }              
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"username", username },
                {"password", password },
                {"name", txtName.Text },
                {"surname", txtSurname.Text },
                {"role", cmbRole.Text },
            };

            Worker user = UserHandler.UserCreated(parameters, dtStartDate.Value.Date);

            UserProfileForm profile = new UserProfileForm(user);
            profile.Show();
            this.Hide();
           
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
