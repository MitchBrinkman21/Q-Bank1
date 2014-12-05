using Q_Bank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Controller
{
    class LoginController
    {
        public FormLogin formLogin { get; set; }

        public LoginController (FormLogin formLogin)
        {
            this.formLogin = formLogin;
            formLogin.button2.Click += processLogin;
            formLogin.button3.Click += openCreateUser;
        }
            public void processLogin (object sender, System.EventArgs e)
            {
                if(checkData())
                {
                    // Ga hier naar de main applicatie.
                }
            }

            public void openCreateUser(object sender, System.EventArgs e)
            {
                CreateUser cu = new CreateUser();
                cu.ShowDialog();
            }
        
        public bool checkData()
            {
                if(!String.IsNullOrEmpty(formLogin.textBox1.Text) && !String.IsNullOrEmpty(formLogin.textBox2.Text))
                {
                    if(checkUsername(formLogin.textBox1.Text))
                    {
                        return false;
                    }
                    if(checkPassword(formLogin.textBox2.Text))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }

            private bool checkUsername(string Username)
            {
                using (var con = new Q_BANKEntities())
                {
                    var query = from c in con.customers
                                where c.username == formLogin.textBox1.Text
                                select c;

                    if (query.Count() != 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            private bool checkPassword(string Password)
            {
                using (var con = new Q_BANKEntities())
                {
                    var query = from c in con.customers
                                where c.password == formLogin.textBox2.Text
                                select c;

                    if(query.Count() != 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }
    
}
