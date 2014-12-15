using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionServer
{
    public partial class FormMain : Form
    {
        public static SqlConnection conn;
        ExecuteThread executeThread;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            conn = DatabaseConnection.CONN;

            buttonStop.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            executeThread = new ExecuteThread();
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            executeThread.keepRunning = false;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void timerInvalidateForm_Tick(object sender, EventArgs e)
        {
            textBoxTransactions.Text = TransactionTask.succesful.ToString();
            textBoxErrors.Text = TransactionTask.errors.ToString();
            textBoxChecksum.Text = ExecuteThread.checksum.ToString();
            textBoxQueue.Text = TransactionTask.transactionsCount.ToString();
            this.Refresh();
        }
    }
}
