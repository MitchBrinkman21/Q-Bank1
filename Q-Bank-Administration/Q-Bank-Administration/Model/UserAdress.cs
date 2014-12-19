using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank_Administration.Model
{
    class UserAdress
    {
        public int customerId;
        public Int16 active;
        public string address;
        public string number;
        public string city;
        public string username;
        public string lastName;
        public string firstName;
        public string bsn;

        public UserAdress(int customerId, string username, string firstName, string lastName, string bsn, Int16 active, string address, string city, string number)
        {
            this.customerId = customerId;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.active = active;
            this.address = address;
            this.city = city;
            this.number = number;
        }
    }
}
