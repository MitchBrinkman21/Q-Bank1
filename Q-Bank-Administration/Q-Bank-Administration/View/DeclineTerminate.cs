using Q_Bank;
using System;
using System.Collections;
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
    public partial class DeclineTerminate : Form
    {
        public Boolean CloseForm { get; set; }

        public DeclineTerminate(List<CheckBox> checkBoxes)
        {
            InitializeComponent();
            query(checkBoxes);
        }

        private void query(List<CheckBox> checkBoxes)
        {
            using (var con = new Q_BANKEntities())
            {
                List<int> accountIdList = new List<int>();
                foreach (CheckBox cb in checkBoxes)
                {
                    accountIdList.Add(Convert.ToInt32(cb.Tag.ToString()));
                }
                var beeindigen = from a in con.accounts
                                 where a.deleteRequest == true
                                 select a;

                beeindigen = beeindigen.Where(a => accountIdList.Contains(a.accountId));

                foreach (account a in beeindigen)
                {
                    label2.Text += a.accountNumber + "\n";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.CloseForm = false;
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.CloseForm = true;
            Close();
        }


    }
}
