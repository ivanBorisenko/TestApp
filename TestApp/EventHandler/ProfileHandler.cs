using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TestApp.EventHandler
{
    public static class ProfileHandler
    {

        private static string _strConn = ConfigurationManager.AppSettings["ConnectionString"];

        private static string strConnect
        {
            get { return _strConn; }
        }

        public static ListView ListOfUsers()
        {
            ListView list = new ListView();
            list.View = View.Details;
            list.AllowColumnReorder = true;
            list.FullRowSelect = true;
            list.Sorting = SortOrder.Ascending;
            list.Columns.Add("Name", 300, HorizontalAlignment.Left);
            list.Columns.Add("Surname", 300, HorizontalAlignment.Left);
            list.Columns.Add("Date", 300, HorizontalAlignment.Left);
            list.Columns.Add("Role", 300, HorizontalAlignment.Left);
            SQLiteConnection conn = new SQLiteConnection();
            try
            {
                conn = new SQLiteConnection(strConnect);
                conn.Open();

                SQLiteCommand CMD = conn.CreateCommand();

                CMD.CommandText = "SELECT PersonalInfoTable.*, RoleTable.role FROM PersonalInfoTable, RoleTable" +
                    " WHERE (id NOT IN (SELECT workerID FROM HeadTable)) AND (PersonalInfoTable.roleID =RoleTable.roleID)";
                SQLiteDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["surname"].ToString());
                    item.SubItems.Add(dr["name"].ToString());
                    item.SubItems.Add(dr["date"].ToString());
                    item.SubItems.Add(dr["role"].ToString());
                    list.Items.Add(item);
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
            return list;
        }
    }

}
