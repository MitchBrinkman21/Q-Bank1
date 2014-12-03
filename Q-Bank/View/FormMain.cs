using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.View;
using Q_Bank.Controller;
using System.Data.SqlClient;

namespace Q_Bank
{
    public partial class FormMain : Form
    {
        public static Q_BANKEntities connection = new Q_BANKEntities();
        public FormMain()
        {
            InitializeComponent();
            Home();
            test();
         }

        private void Home()
        {
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        private void Transaction()
        {

            TabTransaction tt = new TabTransaction(this);
        }

        private void TransactionOverview()
        {

            TabTransactionOverview tto = new TabTransactionOverview(this);
        }

        private void TransactionStatus()
        {

            TabTransactionStatus tts = new TabTransactionStatus(this);                      

        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Wil je afsluiten?", "Afsluiten", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) 
            {
                Application.Exit();
            }   
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;
            switch (i)
            {
                case 0: 
                    Home();
                    break;
                case 1:
                    Transaction();
                    break;
                case 2:
                    TransactionOverview();
                    break;
                case 3:
                    TransactionStatus();
                    break;
                default:
                    Home();
                    break;
            }
        }

        private void test()
        {
            using (var con = new Q_BANKEntities())
            {


                var usersCol = from c in con.users
                               select c.firstName;

                user newUser = new user() { firstName = "jan" };

                con.users.Add(newUser);

                //con.SaveChanges();
            }
        }

    }
}
