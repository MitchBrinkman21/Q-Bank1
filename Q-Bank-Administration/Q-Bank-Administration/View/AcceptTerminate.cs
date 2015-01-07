using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank_Administration.View
{
    public partial class AcceptTerminate : Form
    {
        public Boolean CloseForm { get; set; }

        public AcceptTerminate()
        {
            InitializeComponent();
            this.label2.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CloseForm = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CloseForm = true;
            Close();
        }


    }
}
