using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.Controller;

namespace Q_Bank.View
{
    public class TabTransaction
    {
        public Form FormMain { get; set; }
        public TabTransaction(Form FormMain)
        {
            this.FormMain = FormMain;
        }
    }
}
