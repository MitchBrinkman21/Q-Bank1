using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionServer
{
    class TransactionTask
    {
        private SqlConnection conn;
        public static int errors;
        public static int succesful;
        public static int transactionsCount;
        private List<Transaction> transList = new List<Transaction>();
        private bool moneyReceived;
        Logging log;
        String path;

        public TransactionTask()
        {
            this.conn = FormMain.conn;
            errors = 0;
            succesful = 0;
            log = new Logging();

            path = @"C:\Q-Bank\log.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter w = File.CreateText(path))
                {
                    log.WriteLogging("Log file Created! ", w);
                }
            }
        }

        public List<Transaction> GetQueue()
        {
            List<Transaction> list = new List<Transaction>();

            try
            {
                transactionsCount = 0;
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "   SELECT ta.transactionId, ta.transactionStatusId, ta.sepa, ta.ibanReceiver, ta.nameReceiver, ta.amount, ta.accountId, ta.bic, ta.executeDate, ta.remark, ac.iban, ac.balance " +
                                  "     FROM [transactionQueue] AS ta "+
                                  "     JOIN account AS ac ON ta.accountid = ac.accountId "+
                                  "    WHERE ta.transactionStatusId = 2"+
                                  "      AND ta.executeDate <= cast (GETDATE() as DATE) "+
                                  "      AND ta.sepa = 0";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();
                transList.Clear();

                while (reader.Read())
                {
                    Transaction transaction = new Transaction();
                    transaction.SetTransactionId(Convert.ToInt32(reader[0]));
                    transaction.SetTransactionStatusId(Convert.ToInt32(reader[1]));
                    transaction.SetSepa(Convert.ToInt32(reader[2]));
                    transaction.SetIbanReceiver(reader[3].ToString());
                    transaction.SetNameReceiver(reader[4].ToString());                
                    transaction.SetAmount(Convert.ToDouble(reader[5]));
                    transaction.SetAccountId(Convert.ToInt32(reader[6]));
                    transaction.SetBic(reader[7].ToString());
                    transaction.SetExecuteDate(Convert.ToDateTime(reader[8]));
                    transaction.SetRemark(reader[9].ToString());
                    transaction.SetIban(reader[10].ToString());
                    transaction.SetBalance(Convert.ToDouble(reader[11]));

                    list.Add(transaction);
                    transactionsCount++;

                }
                reader.Close();

            }
            catch (Exception Ex)
            {
                errors++;

                Console.WriteLine(" Exception Type: {0}", Ex.GetType());
                Console.WriteLine("  Message: {0}", Ex.Message);
            }
            return list;
        }

        public Account GetBankAccount(Transaction ta)
        {
            Account account = null;
            SqlTransaction transaction;
            transaction = conn.BeginTransaction("BankAccountTransaction");

            SqlCommand ibanLookup = new SqlCommand();
            SqlDataReader readerIban;

            ibanLookup.CommandText = "SELECT iban, balance FROM account WHERE iban = @iban";
            ibanLookup.CommandType = CommandType.Text;
            ibanLookup.Connection = conn;
            ibanLookup.Transaction = transaction;
            ibanLookup.Parameters.Add("@iban", SqlDbType.VarChar, 45).Value = ta.GetIbanReceiver();

            readerIban = ibanLookup.ExecuteReader();

            if (readerIban.Read())
            {
                account = new Account();
                account.SetIban(readerIban[0].ToString());
                account.SetBalance(Convert.ToDouble(readerIban[1]));
            }
            else
            {
                errors++;
                using (StreamWriter w = File.AppendText(path))
                {
                    log.WriteLogging("TranactionStatusId set to 3 went wrong for TransactionId:" + ta.GetTransactionId().ToString(), w);
                }
            }
            readerIban.Close();
            transaction.Commit();

            return account;
        }

        public int UpdateTransactionStatusTo3(int transactionId, int status)
        {
            int recordsAffected = 0;
            SqlTransaction transaction;
            transaction = conn.BeginTransaction("BankTransaction");

            string updateQuery = "UPDATE [transactionQueue] SET transactionStatusId = @status WHERE transactionId = @transactionId ";

            using (SqlCommand queryUpdateStatus = new SqlCommand(updateQuery))
            {
                // Update Status of transaction 
                queryUpdateStatus.Connection = conn;
                queryUpdateStatus.Transaction = transaction;
                queryUpdateStatus.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = transactionId;
                queryUpdateStatus.Parameters.Add("@status", SqlDbType.Int, 32).Value = status;
                
                try
                {
                    recordsAffected = queryUpdateStatus.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                transaction.Commit();
            }
            return recordsAffected;
        }

        public void UpdateTransactionStatusTo(int transactionId, int status)
        {
            int recordsAffected = 0;
            SqlTransaction transaction;
            transaction = conn.BeginTransaction("BankTransaction");

            string updateQuery = "UPDATE [transactionQueue] SET transactionStatusId = @status WHERE transactionId = @transactionId ";

            using (SqlCommand queryUpdateStatus = new SqlCommand(updateQuery))
            {
                // Update Status of transaction 
                queryUpdateStatus.Connection = conn;
                queryUpdateStatus.Transaction = transaction;
                queryUpdateStatus.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = transactionId;
                queryUpdateStatus.Parameters.Add("@status", SqlDbType.Int, 32).Value = status;

                try
                {
                    recordsAffected = queryUpdateStatus.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                transaction.Commit();
            }
        }
        
        public void Execute() 
        {
            conn.Open();
            transList = GetQueue();
            Account account = null;
            Boolean transactionSucces;

            foreach (Transaction ta in transList)
            {
                transactionSucces = false;
                moneyReceived = false;

                if (ta.GetSepa() == 0)
                {
                    int transactionId = ta.GetTransactionId();
                    int recordsAffected = UpdateTransactionStatusTo3(transactionId, 3);

                    // Execute internal transaction!
                    if (recordsAffected == 1)
                    {
                        account = GetBankAccount(ta);
                    }
                    else
                    {
                        // Write error in log...
                        errors++;
                        using (StreamWriter w = File.AppendText(path))
                        {
                            log.WriteLogging("TranactionStatusId set to 3 went wrong for TransactionId:" + ta.GetTransactionId().ToString(), w);
                        }
                    }

                    SqlTransaction transaction;
                    transaction = conn.BeginTransaction("BankTransaction");

                    // Update account balance!
                    if (account != null)
                    {
                        string updateBalance = "UPDATE account SET balance = @balance WHERE iban = @iban ";

                        // Bankers rounding on balance
                        double newBalance = 0;
                        double balance = account.GetBalance();
                        double amount = ta.GetAmount();

                        double temp = balance + amount;
                        System.Math.Round(temp, 2);
                        newBalance = temp;

                        using (SqlCommand queryUpdateBalance = new SqlCommand(updateBalance))
                        {
                            // Update Status of transaction 
                            queryUpdateBalance.Connection = conn;
                            queryUpdateBalance.Transaction = transaction;
                            queryUpdateBalance.Parameters.Add("@balance", SqlDbType.Decimal, 32).Value = newBalance;
                            queryUpdateBalance.Parameters.Add("@iban", SqlDbType.VarChar, 45).Value = account.GetIban();

                            recordsAffected = 0;

                            try
                            {
                                recordsAffected = queryUpdateBalance.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                                Console.WriteLine("  Message: {0}", ex.Message);

                                try
                                {
                                    transaction.Rollback();
                                }
                                catch (Exception ex2)
                                {
                                    // This catch block will handle any errors that may have occurred 
                                    // on the server that would cause the rollback to fail, such as 
                                    // a closed connection.
                                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                                    Console.WriteLine("  Message: {0}", ex2.Message);
                                }
                                UpdateTransactionStatusTo(transactionId, 2);
                            }

                            if (recordsAffected == 1)
                            {
                                moneyReceived = true;
                            }
                            else
                            {
                                // Weite error in log...
                                errors++;
                                using (StreamWriter w = File.AppendText(path))
                                {
                                    log.WriteLogging("Error in updating balance of receiver TransactionId:" + ta.GetTransactionId().ToString(), w);
                                }
                            }
                            // Delete account data...
                            account = null;
                        }
                    }

                    if (moneyReceived == true)
                    {
                        // Update balance Transaction owner!
                        string updateBalance = "UPDATE account SET balance = @balance WHERE iban = @iban ";

                        // Bankers rounding on balance
                        double newBalance = 0;
                        double balance = ta.GetBalance();
                        double amount = ta.GetAmount();

                        double temp = balance - amount;
                        System.Math.Round(temp, 2);
                        newBalance = temp;

                        using (SqlCommand queryUpdateBalance = new SqlCommand(updateBalance))
                        {
                            // Update Status of transaction 
                            queryUpdateBalance.Connection = conn;
                            queryUpdateBalance.Transaction = transaction;
                            queryUpdateBalance.Parameters.Add("@balance", SqlDbType.Decimal, 32).Value = newBalance;
                            queryUpdateBalance.Parameters.Add("@iban", SqlDbType.VarChar, 45).Value = ta.GetIban();

                            recordsAffected = 0;
                            try
                            {
                                recordsAffected = queryUpdateBalance.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                                Console.WriteLine("  Message: {0}", ex.Message);

                                try
                                {
                                    transaction.Rollback();
                                }
                                catch (Exception ex2)
                                {
                                    // This catch block will handle any errors that may have occurred 
                                    // on the server that would cause the rollback to fail, such as 
                                    // a closed connection.
                                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                                    Console.WriteLine("  Message: {0}", ex2.Message);
                                }
                                UpdateTransactionStatusTo(transactionId, 2);
                            }
                            if (recordsAffected != 1)
                            {
                                using (StreamWriter w = File.AppendText(path))
                                {
                                    log.WriteLogging("Error in updating balance of sender TransactionId:" + ta.GetTransactionId().ToString(), w);
                                }
                            }

                            string finishQuery = "UPDATE [transactionQueue] SET transactionStatusId = 4 WHERE transactionId = @transactionId ";

                            using (SqlCommand queryUpdateStatus = new SqlCommand(finishQuery))
                            {
                                // Update Status of transaction 
                                queryUpdateStatus.Connection = conn;
                                queryUpdateStatus.Transaction = transaction;
                                queryUpdateStatus.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = transactionId;

                                recordsAffected = 0;
                                try
                                {
                                    recordsAffected = queryUpdateStatus.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                                    Console.WriteLine("  Message: {0}", ex.Message);

                                    try
                                    {
                                        transaction.Rollback();
                                    }
                                    catch (Exception ex2)
                                    {
                                        // This catch block will handle any errors that may have occurred 
                                        // on the server that would cause the rollback to fail, such as 
                                        // a closed connection.
                                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                                        Console.WriteLine("  Message: {0}", ex2.Message);
                                    }
                                    UpdateTransactionStatusTo(transactionId, 2);
                                }

                                if (recordsAffected == 1)
                                {
                                    // Insert Query into Transaction Table...
                                    string insertQuery = " INSERT INTO [transaction] " +
                                                            " (transactionId, amount, sepa, ibanReceiver, nameReceiver, accountId, commitDateTime, datetime, bic, executeDate, remark)" +
                                                            " VALUES " +
                                                            "(@transactionId, @amount, @sepa, @ibanReceiver, @nameReceiver, @accountId, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @bic, @executeDate, @remark) ";

                                    using (SqlCommand queryInsertTransaction = new SqlCommand(insertQuery))
                                    {
                                        // Update Status of transaction 
                                        queryInsertTransaction.Connection = conn;
                                        queryInsertTransaction.Transaction = transaction;
                                        queryInsertTransaction.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = ta.GetTransactionId();
                                        queryInsertTransaction.Parameters.Add("@sepa", SqlDbType.Int, 32).Value = ta.GetSepa();
                                        queryInsertTransaction.Parameters.Add("@amount", SqlDbType.Int, 32).Value = ta.GetAmount();
                                        queryInsertTransaction.Parameters.Add("@ibanReceiver", SqlDbType.VarChar, 32).Value = ta.GetIbanReceiver();
                                        queryInsertTransaction.Parameters.Add("@nameReceiver", SqlDbType.VarChar, 32).Value = ta.GetNameReceiver();
                                        queryInsertTransaction.Parameters.Add("@accountId", SqlDbType.Int, 32).Value = ta.GetAccountId();
                                        queryInsertTransaction.Parameters.Add("@bic", SqlDbType.VarChar, 32).Value = ta.GetBic();
                                        queryInsertTransaction.Parameters.Add("@executeDate", SqlDbType.DateTime, 32).Value = ta.GetExecuteDate();
                                        queryInsertTransaction.Parameters.Add("@remark", SqlDbType.VarChar, 32).Value = ta.GetRemark();

                                        recordsAffected = 0;
                                        try
                                        {
                                            recordsAffected = queryInsertTransaction.ExecuteNonQuery();
                                            transactionSucces = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                                            Console.WriteLine("  Message: {0}", ex.Message);

                                            try
                                            {
                                                transaction.Rollback();
                                            }
                                            catch (Exception ex2)
                                            {
                                                // This catch block will handle any errors that may have occurred 
                                                // on the server that would cause the rollback to fail, such as 
                                                // a closed connection.
                                                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                                                Console.WriteLine("  Message: {0}", ex2.Message);
                                            }
                                            UpdateTransactionStatusTo(transactionId, 2);
                                        }
                                    }

                                }
                                else
                                {
                                    // Weite error in log...
                                    errors++;
                                    using (StreamWriter w = File.AppendText(path))
                                    {
                                        log.WriteLogging("TranactionStatusId set to 4 went wrong for TransactionId:" + ta.GetTransactionId().ToString(), w);
                                    }
                                }
                            }

                            // Delete account data...
                            account = null;
                        }
                    }

                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception Ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            // This catch block will handle any errors that may have occurred 
                            // on the server that would cause the rollback to fail, such as 
                            // a closed connection.
                            Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                            Console.WriteLine("  Message: {0}", ex2.Message);
                        }
                        UpdateTransactionStatusTo(transactionId, 2);
                    }

                    if (transactionSucces == true)
                    {
                        int deletequeue = DeleteQueueRecord(ta.GetTransactionId());
                        succesful++;
                    }
                }
            }
            transList.Clear();
            conn.Close();
        }

        public int DeleteQueueRecord(int transactionId)
        {
            int recordsAffected = 0;
            SqlTransaction transaction;
            transaction = conn.BeginTransaction("DeleteTransaction");

            string deleteQuery = "DELETE FROM [transactionQueue] WHERE transactionId = @transactionId ";

            using (SqlCommand queryUpdateStatus = new SqlCommand(deleteQuery))
            {
                // Update Status of transaction 
                queryUpdateStatus.Connection = conn;
                queryUpdateStatus.Transaction = transaction;
                queryUpdateStatus.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = transactionId;

                try
                {
                    recordsAffected = queryUpdateStatus.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);

                        using (StreamWriter w = File.AppendText(path))
                        {
                            log.WriteLogging("TransactionQueue could'n delete record for TransactionId:" + transactionId.ToString(), w);
                        }
                    }
                }
                transaction.Commit();
            }
            return recordsAffected;
        }      
    }  
}
