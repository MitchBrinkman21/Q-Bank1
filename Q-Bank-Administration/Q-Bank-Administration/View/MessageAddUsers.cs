using Q_Bank_Administration.Controller;
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
    public partial class MessageAddUsers : Form
    {
        public Boolean CloseForm { get; set; }
        public MessageAddUsers()
        {
            InitializeComponent();
            MessageAddUsersController mauc = new MessageAddUsersController(this);
        }
    }
}
