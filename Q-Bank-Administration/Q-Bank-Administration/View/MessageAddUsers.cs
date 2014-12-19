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
        public MessageAddUsersController mauc { get; set; }
        public MessageAddUsers()
        {
            InitializeComponent();
            mauc = new MessageAddUsersController(this);
        }

        private void MessageAddUsers_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(System.Drawing.Color.Gray);
            e.Graphics.DrawLine(pen, 82, 156, 461, 156);
        }
    }
}
