using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Controller;

namespace Q_Bank.View
{
    public class TabTransactionOverview
    {
        public FormMain formMain { get; set; }
        public TransactionOverviewController toc { get; set; }
        public TabTransactionOverview(FormMain formMain)
        {
            this.formMain = formMain;
            toc = new TransactionOverviewController(this);
        }
    }
}
