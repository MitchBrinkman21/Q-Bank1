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
            TransactionController tc = new TransactionController(this);
            TransactionOverviewController toc = new TransactionOverviewController(this);
            TabMailingList tts = new TabMailingList(this);
            InboxController ic = new InboxController(this);
        }

        private void Home()
        {
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
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

        private void rekeningBeëindigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminateAccountRequestController tac = new TerminateAccountRequestController(this);
        }

    }
}
