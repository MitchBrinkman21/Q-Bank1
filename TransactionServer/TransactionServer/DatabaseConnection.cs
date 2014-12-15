using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionServer
{
    class DatabaseConnection
    {
        public static SqlConnection CONN;

        public DatabaseConnection()
        {
            string connetionString = null;
            connetionString = "Data Source=FEIKO-LAPTOP\\SQLEXPRESS;Initial Catalog=Q_Bank;User ID=sa;Password=Feiko1337";
            CONN = new SqlConnection(connetionString);
            try
            {
                CONN.Open();
                CONN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection! Issue: " + ex);
            }
            
        }
    }
}
