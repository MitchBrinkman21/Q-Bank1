using Q_Bank;
using Q_Bank_Administration.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank_Administration.Controller
{
    class LoginController
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
                if (id >= 1)
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
                    formLogin.label5.Text = String.Empty;
                    loginNo = "";
                    validated = false;
                } 
            }
            else
            {
                formLogin.label4.Text = "Onjuist wachtwoord en/of gebruikersnaam";
            }
        }

        public bool checkLogin()
        {
            if (!String.IsNullOrEmpty(formLogin.textBox1.Text) && !String.IsNullOrEmpty(formLogin.textBox2.Text))
            {
                using (var con = new Q_BANKEntities())
                {
                    var query = from c in con.employees
                                where c.username == formLogin.textBox1.Text
                                select c;

                    if (query.Count() != 0)
                    {
                        string encodedSalt = query.First().password;
                        string encodedKey = query.First().key;
                        PasswordEncryption pe = new PasswordEncryption();

                        if (pe.authenticate(formLogin.textBox2.Text, encodedSalt, encodedKey))
                        {
                            id = query.First().employeeId;
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
