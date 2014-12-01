using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.Controller
{
    public class TransactionsStatusController
    {
        private View.TabTransactionStatus tss;
        private bool AllesGeselecteerd;
        public TransactionsStatusController(View.TabTransactionStatus tss)
        {
            this.tss = tss;
            AllesGeselecteerd = false;
        }


        public void SelectAllHandler(object sender, System.EventArgs e)
        {
            if (!AllesGeselecteerd)
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = true;
                }
                AllesGeselecteerd = true;
            }
            else
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = false;
                }
                AllesGeselecteerd = false;
            }
        }

        public void checkchanged(object sender, EventArgs e)
        {
            //var selected = from
        }
    }
}
