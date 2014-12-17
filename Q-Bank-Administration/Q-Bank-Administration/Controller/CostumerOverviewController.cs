using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank_Administration.Controller
{
    class CostumerOverviewController
    {
        public FormMain formMain { get; set; }

        public CostumerOverviewController(FormMain formMain)
        {
            this.formMain = formMain;
        }

        private void tabControl(object sender, EventArgs e)
        {
        }
    }
}
