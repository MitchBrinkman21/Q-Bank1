﻿using Q_Bank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.Controller
{
    public class LoginController
    {
        public FormLogin formLogin { get; set; }
        public FormMain a;
        private int id = 0;
        private Boolean validated = false;
        String loginNo = "";

        public LoginController(FormLogin formLogin)
        {
            this.formLogin = formLogin;
            formLogin.button2.Click += processLogin;
            formLogin.button3.Click += openCreateUser;
            formLogin.AcceptButton = formLogin.button2;
        }

        void a_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLogin.Show();
        }

        public void processLogin(object sender, System.EventArgs e)
        {

            if (checkLogin())
            {
                if (formLogin.textBox3.Enabled)
                {
                    if (id >= 1)
                    {
                        if (formLogin.textBox3.Text.Equals(loginNo))
                        {
                            a = new FormMain(id);
                            a.FormClosed += a_FormClosed;
                            a.Show();
                            formLogin.Hide();
                            formLogin.label4.Text = String.Empty;
                            formLogin.textBox1.Text = String.Empty;
                            formLogin.textBox2.Text = String.Empty;
                            formLogin.AcceptButton = formLogin.button2;
                            id = 0;
                            formLogin.textBox3.Text = String.Empty;
                            formLogin.textBox3.Enabled = false;
                            loginNo = "";
                            validated = false;
                        }
                        else
                        {
                            formLogin.label4.Text = "Probeer opnieuw";
                            formLogin.textBox1.Text = String.Empty;
                            formLogin.textBox2.Text = String.Empty;
                            formLogin.AcceptButton = formLogin.button2;
                            id = 0;
                            formLogin.textBox3.Text = String.Empty;
                            formLogin.textBox3.Enabled = false;
                            loginNo = "";
                        }
                    }
                }
                else
                {
                    formLogin.textBox3.Enabled = true;
                    formLogin.textBox3.Focus();
                }
            }
            else
            {
                formLogin.label4.Text = "Onjuist wachtwoord en/of gebruikersnaam";
            }
        }

        public void openCreateUser(object sender, System.EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.ShowDialog();
        }

        public bool checkLogin()
        {
            if (!String.IsNullOrEmpty(formLogin.textBox1.Text) && !String.IsNullOrEmpty(formLogin.textBox2.Text))
            {
                using (var con = new Q_BANKEntities())
                {
                    var query = from c in con.customers
                                where c.username == formLogin.textBox1.Text
                                select c;

                    if (query.Count() != 0)
                    {
                        string encodedSalt = query.First().password;
                        string encodedKey = query.First().key;
                        PasswordEncryption pe = new PasswordEncryption();

                        if (pe.authenticate(formLogin.textBox2.Text, encodedSalt, encodedKey))
                        {
                            id = query.First().customerId;
                            if (!formLogin.textBox3.Enabled)
                            {
                                Random rnd = new Random();
                                loginNo = "";
                                for (int i = 0; i < 8; i++)
                                {
                                    loginNo += Convert.ToString(rnd.Next(10));
                                }
                                try
                                {
                                    var emailquery = from c in con.customeremails
                                                     where c.customerId == id
                                                     select c;

                                    MailMessage mail = new MailMessage();

                                    mail.From = new MailAddress("qbankquintor@gmail.com");
                                    mail.To.Add(emailquery.First().email);
                                    mail.Subject = "Authorisatiecode";
                                    mail.Body = "Code: " + loginNo;

                                    var client = new SmtpClient("smtp.gmail.com", 587)
                                    {
                                        Credentials = new NetworkCredential("qbankquintor@gmail.com", "windesheim_project"),
                                        EnableSsl = true
                                    };
                                    client.Send(mail);
                                    MessageBox.Show("De code is naar uw mail gestuurd");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            query = null;
                            return true;
                        }
                        return false;
                    }
                }                        
            }
            return false;
        }
    }

}
