using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionServer
{
    public class DatabaseConnection
    {
        public static SqlConnection CONN;

        public DatabaseConnection()
        {
            string connetionString = null;
            connetionString = "Data Source=Mitch-MacBook\\SQLEXPRESS;Initial Catalog=Q_Bank;User ID=sa;Password=VanDorland1";
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
