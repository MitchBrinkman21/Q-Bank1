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
    public partial class UserSearch : Form
    {
        public Boolean CloseForm { get; set; }
        public UserSearch()
        {
            InitializeComponent();
            userSearchOrderByCombobobox.SelectedIndex = 0;
        }

        private void buttonAnnuleren_Click(object sender, EventArgs e)
        {
            this.CloseForm = false;
            Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(CheckValidText())
             {
                this.CloseForm = true;
                Close();
            }
            else
            {
                MessageBox.Show("geen tekst", "Error");
            }  
        }

        private bool CheckValidText()
        {
            if (String.IsNullOrWhiteSpace(textBoxusername.Text) && String.IsNullOrWhiteSpace(textBoxFirstName.Text) && String.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
