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
            Home();
            this.id = id;
        }

        private void Home()
        {
        }

        private void CustomerOverview()
        {
            CustomerOverviewController coc = new CustomerOverviewController(this);
        }

        private void EmployeeOverview()
        {

        }

        private void RequestedAccounts()
        {

        }

        private void TerminateAccounts()
        {

        }

        private void Messages()
        {
            MessageController mc = new MessageController(this);
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
                    CustomerOverview();
                    break;
                case 2:
                    EmployeeOverview();
                    break;
                case 3:
                    RequestedAccounts();
                    break;
                case 4:
                    TerminateAccounts();
                    break;
                case 5:
                    Messages();
                    break;
                default:
                    Home();
                    break;
            }
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
