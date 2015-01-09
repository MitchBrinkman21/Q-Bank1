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

namespace Q_Bank_Administration.View
{
    public partial class UserMenu : Form
    {
        private int id;
        public UserMenu(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountOverviewController aoc = new AccountOverviewController(id);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount(id);
            ca.ShowDialog();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
