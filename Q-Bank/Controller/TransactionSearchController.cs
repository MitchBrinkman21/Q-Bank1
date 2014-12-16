using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q_Bank.View;
using System.Text.RegularExpressions;

namespace Q_Bank.Controller
{
    public class TransactionSearchController
    {
        public TransactionSearch ts { get; set; }
        public Boolean validText { get; set; }
        public String error { get; set; }

        public TransactionSearchController(TransactionSearch ts)
        {
            this.ts = ts;
        }

        public void checkValidText()
        {
            validText = true;
            error = "";

            if (ts.TransactionSearchAccountCombobox.SelectedIndex == 0)
            {
                error = "Geen rekening geselecteerd.\n";
                validText = false;
            }
            // Check if entered data is correct
            if (ts.TransactionSearchCombobox.SelectedIndex == 1)
            {
                if (ts.beginDatePicker.Value > ts.endDatePicker.Value)
                {
                    error += "Begindatum moet kleiner zijn dan de einddatum.";
                    validText = false;
                }
            }
        }
    }
}
