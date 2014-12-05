﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.View
{
    public class ComboBoxItem
    {
        public int Value;
        public string Iban;
        public string Text;
        public ComboBoxItem(int val, string text)
        {
            Value = val;
            Text = text;
        }

        public ComboBoxItem(int val, string iban, string text)
        {
            Iban = iban;
            Value = val;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
