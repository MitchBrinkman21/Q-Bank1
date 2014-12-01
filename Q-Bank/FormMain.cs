using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = new Q_BANKEntities())
            {


                var usersCol = from c in con.users
                            select c.firstName;

                user newUser = new user() {firstName = "jan"  };

                con.users.Add(newUser);

                con.SaveChanges();


                //con.Open();
                //EntityCommand cmd = con.CreateCommand();
                //cmd.CommandText = "SELECT VALUE us FROM Q_BANKEntities.Users as us";
                //Dictionary<int, int> dict = new Dictionary<int, int>();
                //using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                //{
                //    while (rdr.Read())
                //    {
                //        int a = rdr.GetInt32(0);
                //        var b = rdr.GetInt32(1);
                //        dict.Add(a, b);
                //    }
                //}
            }
        }
    }
}
