using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;

namespace TestApp.Forms
{
    public partial class BaseSalaryForm : Form
    {
        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        public BaseSalaryForm()
        {
            InitializeComponent();
        }

        private void BaseSalaryForm_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();
                CMD.CommandText = "UPDATE RoleTable SET baseSalary = @baseSalary, coeffDate = @coeffDate, coeffSur = @coeffSur, maxDate = @maxDate WHERE role = @role";
                CMD.Parameters.Add("@role", System.Data.DbType.String).Value = cmbRole.SelectedItem.ToString();
                CMD.Parameters.Add("@baseSalary", System.Data.DbType.Int16).Value = Convert.ToInt16(txtBaseSalary.Text);
                CMD.Parameters.Add("@coeffDate", System.Data.DbType.Int16).Value = Convert.ToInt16(txtCoeffDate.Text);
                CMD.Parameters.Add("@coeffSur", System.Data.DbType.Double).Value = Convert.ToDouble(txtCoeffSub.Text);
                CMD.Parameters.Add("@maxDate", System.Data.DbType.Int16).Value = Convert.ToInt16(txtMaxCoeff.Text);
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
            lblChanged.Text = "Данные обновлены";
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();
                txtCoeffSub.Visible = true;
                if (cmbRole.SelectedItem.ToString() == "Employee")
                {
                    txtCoeffSub.Visible = false;
                }
                SQLiteCommand CMD = conn.CreateCommand();
                CMD.CommandText = "SELECT* FROM RoleTable WHERE role = @role";
                CMD.Parameters.Add("@role", System.Data.DbType.String).Value = cmbRole.SelectedItem.ToString();
                SQLiteDataReader SQL = CMD.ExecuteReader();
                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        txtBaseSalary.Text = (SQL["baseSalary"].ToString());
                        txtCoeffDate.Text = (SQL["coeffDate"].ToString());
                        txtCoeffSub.Text = (SQL["coeffSur"].ToString());
                        txtMaxCoeff.Text = (SQL["maxDate"].ToString());
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
        }

    }
}
