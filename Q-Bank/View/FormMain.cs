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
        public Boolean afgemeld = false;
        public int id;

        public FormMain(int id)
        {
            InitializeComponent();
            Home();
            this.id = id;
        }

        private void Home()
        {
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        private void Transaction()
        {
            TransactionController tc = new TransactionController(this);
        }

        private void TransactionOverview()
        {
            TransactionOverviewController toc = new TransactionOverviewController(this);
        }

        private void TransactionStatus()
        {

            TabMailingList tts = new TabMailingList(this);

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

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!afgemeld)
            {
                Application.Exit();
            }
        }

        private void afmeldenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Wilt u afmelden?", "Afmelden", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                afgemeld = true;
                this.Close();
            }
        }

    }
}
