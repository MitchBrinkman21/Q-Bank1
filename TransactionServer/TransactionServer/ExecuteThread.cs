using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionServer
{
    class ExecuteThread
    {
        public bool keepRunning;
        SqlConnection conn;
        public static int checksum;
        TransactionTask transactionTask;
 
        public ExecuteThread()
        {
            checksum = 0;
            transactionTask = new TransactionTask();
            keepRunning = true;

            Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Start();        
        }

        public void WorkThreadFunction()
        {
            try
            {
                while (keepRunning)
                {
                    checksum++;
                    transactionTask.Execute();
                    Thread.Sleep(400);
                }
            }
            catch (Exception Ex)
            {
                // Write error in log!
            }
        }
    }
}
