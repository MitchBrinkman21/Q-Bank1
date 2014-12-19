using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank_Administration.Controller;

namespace Q_Bank_Administration.View
{
    public partial class CreateAccount : Form
    {
        public CreateAccount(int customerId)
        {
            InitializeComponent();
            CreateAccountController cac = new CreateAccountController(this, customerId);
        }
    }
}
