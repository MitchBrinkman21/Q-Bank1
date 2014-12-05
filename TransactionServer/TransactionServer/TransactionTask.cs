using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private List<Transaction> transList = new List<Transaction>();
        private Account account;
        private bool moneyReceived;

        public TransactionTask()
        {
            this.conn = FormMain.conn;
            errors = 0;
            succesful = 0;
            Execute();
        }


        public void Execute() 
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "   SELECT ta.transactionId, ta.transactionStatusId, ta.sepa, ta.ibanReceiver, ta.amount, ac.iban, ac.balance "+
                                  "     FROM [transaction] AS ta JOIN account AS ac ON ta.accountid = ac.accountId "+
                                  "    WHERE transactionStatusId = 2"+
                                  "      AND ta.executeDate <= cast (GETDATE() as DATE) "+
                                  "      AND ta.sepa = 0";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    transList.Clear();

                    Transaction transaction = new Transaction();
                    transaction.SetTransactionId(Convert.ToInt32(reader[0]));
                    transaction.SetTransactionStatusId(Convert.ToInt32(reader[1]));
                    transaction.SetSepa(Convert.ToInt32(reader[2]));
                    transaction.SetIbanReceiver(reader[3].ToString());
                    transaction.SetAmount(Convert.ToDouble(reader[4]));
                    transaction.SetIban(reader[5].ToString());
                    transaction.SetBalance(Convert.ToDouble(reader[6]));

                    transList.Add(transaction);

                }
                reader.Close();
                conn.Close();

                foreach(Transaction ta in transList)
                {
                    moneyReceived = false;

                    if (ta.GetSepa() == 0)
                    {
                        int transactionId = ta.GetTransactionId();

                        string updateQuery = "UPDATE [transaction] SET transactionStatusId = 3 WHERE transactionId = @transactionId ";

                        using (SqlCommand queryUpdateStatus = new SqlCommand(updateQuery))
                        {
                            // Update Status of transaction 
                            queryUpdateStatus.Connection = conn;
                            queryUpdateStatus.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = transactionId;

                            int recordsAffected = 0;
                            conn.Open();
                            recordsAffected = queryUpdateStatus.ExecuteNonQuery();
                            conn.Close();

                            // Execute internal transaction!
                            if (recordsAffected == 1)
                            {
                                SqlCommand ibanLookup = new SqlCommand();
                                SqlDataReader readerIban;

                                ibanLookup.CommandText = "SELECT iban, balance FROM account WHERE iban = @iban";
                                ibanLookup.CommandType = CommandType.Text;
                                ibanLookup.Connection = conn;
                                ibanLookup.Parameters.Add("@iban", SqlDbType.VarChar, 45).Value = ta.GetIbanReceiver();

                                conn.Open();
                                readerIban = ibanLookup.ExecuteReader();

                                if (readerIban.Read())
                                {
                                    account = new Account();
                                    account.SetIban(readerIban[0].ToString());
                                    account.SetBalance(Convert.ToDouble(readerIban[1]));
                                }
                                conn.Close();
                            }
                            else
                            {
                                // Write error in log...
                                errors++;
                            }

                            // Update account balance!
                            if(account != null)
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
                                    queryUpdateBalance.Parameters.Add("@balance", SqlDbType.Decimal, 32).Value = newBalance;
                                    queryUpdateBalance.Parameters.Add("@iban", SqlDbType.VarChar, 45).Value = account.GetIban();

                                    recordsAffected = 0;
                                    conn.Open();
                                    recordsAffected = queryUpdateBalance.ExecuteNonQuery();
                                    if (recordsAffected == 1)
                                    {
                                        moneyReceived = true;
                                    }
                                    else
                                    {
                                        // Weite error in log...
                                        errors++;
                                    }
                                    conn.Close();
                                    // Delete account data...
                                    account = null;
                                }
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
                                queryUpdateBalance.Parameters.Add("@balance", SqlDbType.Decimal, 32).Value = newBalance;
                                queryUpdateBalance.Parameters.Add("@iban", SqlDbType.VarChar, 45).Value = ta.GetIban();

                                int recordsAffected = 0;
                                conn.Open();
                                recordsAffected = queryUpdateBalance.ExecuteNonQuery();
                                conn.Close();

                                string finishQuery = "UPDATE [transaction] SET transactionStatusId = 4, commitDateTime = CURRENT_TIMESTAMP WHERE transactionId = @transactionId ";

                                using (SqlCommand queryUpdateStatus = new SqlCommand(finishQuery))
                                {
                                    // Update Status of transaction 
                                    queryUpdateStatus.Connection = conn;
                                    queryUpdateStatus.Parameters.Add("@transactionId", SqlDbType.Int, 32).Value = transactionId;

                                    conn.Open();
                                    recordsAffected = 0;
                                    recordsAffected = queryUpdateStatus.ExecuteNonQuery();
                                    if (recordsAffected == 1)
                                    {
                                        succesful++;
                                    }
                                    else
                                    {
                                        // Weite error in log...
                                        errors++;
                                    }
                                    conn.Close();
                                }

                                // Delete account data...
                                account = null;
                            }
                        }
                    }
                    else
                    {
                        //Create SEPA file...
                        errors++;
                    }
                }

                transList.Clear();
            }
            catch (Exception Ex)
            {
                // write error in log...
                errors++;
            }
        }
    }
}
