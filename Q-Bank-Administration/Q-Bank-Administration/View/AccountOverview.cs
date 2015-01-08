using System;
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
    public partial class AccountOverview : Form
    {
        public int customerId;
        public AccountOverview(int id)
        {
            customerId = id;
            InitializeComponent();
        }
    }
}
