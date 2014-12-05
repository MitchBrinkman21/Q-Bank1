using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.Pro6PPServiceReference;

namespace Q_Bank.Controller
{
    public class AddressGenerator
    {
        public string postalCode { get; set; }
        public string houseNumber { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string province { get; set; }

        public AddressGenerator(string postalCode, string houseNumber)
        {
            this.postalCode = postalCode;
            this.houseNumber = houseNumber;
        }

        public void generateAddressDetails()
        {
            if (!postalCode.Equals("") && !houseNumber.Equals("")) { 
                Pro6PP_PortClient client = new Pro6PP_PortClient();

                // Setting up the parameters
                String auth_key = "r4j33LL9fyoSOoau";

                // Given this 6PP postcode, get the address
                Address[] addresses = client.autocomplete(auth_key, postalCode, 0, houseNumber);
                foreach (Address address in addresses)
                {
                    street = address.street;
                    city = address.city;
                    province = address.province;
                }
            }
        }
    }
}
