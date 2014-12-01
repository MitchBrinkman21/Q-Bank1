using Q_Bank.View;
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
        private TabTransactionStatus tts;
        public FormMain()
        {
            InitializeComponent();
            Home();
        }
        private void Home()
        {
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        private void Transaction()
        {
            InitializeComponent();
            TabTransaction tt = new TabTransaction(this);
        }

        private void TransactionOverview()
        {
            TabTransactionOverview tto = new TabTransactionOverview(this);
        }

        private void TransactionStatus()
        {
            tts = new TabTransactionStatus(this);
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
            int i = 0;
            //tabControl1.SelectedIndex;
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


        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = new EntityConnection("name=Q_BANKEntities"))
            {
                con.Open();
                EntityCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT VALUE us FROM Q_BANKEntities.Users as us";
                Dictionary<int, int> dict = new Dictionary<int, int>();
                using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                {
                    while (rdr.Read())
                    {
                        int a = rdr.GetInt32(0);
                        var b = rdr.GetInt32(1);
                        dict.Add(a, b);
                    }
                }
            }
        }
    }
}
