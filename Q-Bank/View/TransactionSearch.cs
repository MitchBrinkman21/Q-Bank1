using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.View
{
    public partial class TransactionSearch : Form
    {
        public Boolean CloseForm { get; set; }
        public TransactionSearch()
        {
            InitializeComponent();
            TransactionSearchCombobox.SelectedIndex = 0;
        }

        private void TransactionSearchButtonCancel_Click(object sender, EventArgs e)
        {
            this.CloseForm = false;
            Close();
        }

        private void TransactionSearchButtonSearch_Click(object sender, EventArgs e)
        {
            this.CloseForm = true;
            Close();
        }

        private void TransactionSearchCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TransactionSearchCombobox.SelectedIndex == 0)
            {
                labelFirstName.Visible = true;
                labelLastName.Visible = true;
                textBoxFirstName.Visible = true;
                textBoxLastName.Visible = true;
                labelBeginDate.Visible = false;
                labelEndDate.Visible = false;
                beginDatePicker.Visible = false;
                endDatePicker.Visible = false;

            }
            else
            {
                labelFirstName.Visible = false;
                labelLastName.Visible = false;
                textBoxFirstName.Visible = false;
                textBoxLastName.Visible = false;
                labelBeginDate.Visible = true;
                labelEndDate.Visible = true;
                beginDatePicker.Visible = true;
                endDatePicker.Visible = true;
            }
        }
    }
}
