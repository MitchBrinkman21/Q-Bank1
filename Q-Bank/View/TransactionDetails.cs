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
    public partial class TransactionDetails : Form
    {
        transaction d;
        public TransactionDetails(int tID)
        {
            InitializeComponent();
            using (var con = new Q_BANKEntities())
            {
                var details = from a in con.transactions 
                                  where a.transactionId == tID
                                  select a;
                
                foreach (transaction item in details)
                {
                    d = item;
                    
                }
                uitvoerdatumLabel.Text = d.executeDate.ToString();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
