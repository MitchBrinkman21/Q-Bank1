using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.View
{
    public class TabTransactionOverview
    {
        public Form FormMain { get; set; }
        public TabTransactionOverview(Form FormMain)
        {
            this.FormMain = FormMain;
        }
    }
}
