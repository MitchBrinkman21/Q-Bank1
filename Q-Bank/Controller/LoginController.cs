using Q_Bank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank.Controller
{
    class LoginController
    {
        public FormLogin formLogin { get; set; }
        public FormMain a;
        private int id = 0;

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
                // Ga hier naar de main applicatie.
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

        public bool checkData()
        {
            if (!String.IsNullOrEmpty(formLogin.textBox1.Text) && !String.IsNullOrEmpty(formLogin.textBox2.Text))
            {
                if (checkLogin())
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        private bool checkLogin()
        {
            if (!String.IsNullOrEmpty(formLogin.textBox1.Text) && !String.IsNullOrEmpty(formLogin.textBox2.Text))
            {
                using (var con = new Q_BANKEntities())
                {
                    var query = from c in con.customers
                                where c.password == formLogin.textBox2.Text && c.username == formLogin.textBox1.Text
                                select c;

                    if (query.Count() != 0)
                    {
                        id = query.First().customerId;
                        query = null;
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }
    }

}
