using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank_Administration.Controller;

namespace Q_Bank_Administration
{
    public partial class FormMain : Form
    {
        public int id { get; set; }
        public Boolean loggedOut { get; set; }

        public FormMain(int id)
        {
            InitializeComponent();
            this.id = id;
            CustomerOverviewController coc = new CustomerOverviewController(this);
            TerminateAccountsController tac = new TerminateAccountsController(this);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loggedOut)
            {
                Application.Exit();
            }
        }

        private void afmeldenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Wilt u afmelden?", "Afmelden", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                loggedOut = true;
                this.Close();
            }
        }
    }
}
