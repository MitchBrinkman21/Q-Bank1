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
        public int id { get; set; }
        public TransactionSearch(int id)
        {
            this.id = id;
            InitializeComponent();
            FillAccountCombobox();
            TransactionSearchCombobox.SelectedIndex = 0;
            TransactionSearchAccountCombobox.SelectedIndex = 0;
            TransactionSearchOrderByCombobobox.SelectedIndex = 0;
        }

        private void TransactionSearchButtonCancel_Click(object sender, EventArgs e)
        {
            this.CloseForm = false;
            Close();
        }

        private void TransactionSearchButtonSearch_Click(object sender, EventArgs e)
        {
            if (TransactionSearchCombobox.SelectedIndex == 1)
            {
                if (beginDatePicker.Value > endDatePicker.Value)
                {
                    MessageBox.Show("Begindatum moet kleiner zijn dat einddatum!");
                }
                else
                {
                    this.CloseForm = true;
                    Close();
                }
            }
            else
            {
                this.CloseForm = true;
                Close();
            }
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

        private void FillAccountCombobox()
        {
            using (var con = new Q_BANKEntities())
            {
                TransactionSearchAccountCombobox.Items.Clear();
                var accountsCol = from a in con.accounts
                                  where a.customerId == this.id
                                  select a;

                if (accountsCol.Count() > 0)
                {
                    TransactionSearchAccountCombobox.Items.Add(new ComboBoxItem(0, "Alle rekeningen"));
                    TransactionSearchAccountCombobox.SelectedIndex = 0;
                    foreach (account a in accountsCol)
                    {
                        TransactionSearchAccountCombobox.Items.Add(new ComboBoxItem(a.accountId, a.iban.ToString(), a.iban.ToString()));
                    }
                }
                else
                {
                    TransactionSearchAccountCombobox.Items.Add(new ComboBoxItem(-1, "Geen rekeningen gevonden"));
                    TransactionSearchAccountCombobox.SelectedIndex = 0;
                }
            }
        }
    }
}
