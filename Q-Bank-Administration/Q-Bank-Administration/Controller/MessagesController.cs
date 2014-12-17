using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank_Administration.Controller
{
    public class MessagesController
    {
        public FormMain formMain { get; set; }

        public MessagesController(FormMain formMain)
        {
            this.formMain = formMain;
        }
    }
}
