using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public class Individual : Client
    {
        public Individual(string name)
            : this(name, 0, "")
        {
        }

        public Individual(string name, long accountNumber)
            : this(name, accountNumber, "")
        {
        }

        public Individual(string name, long accountNumber, string address)
        {
            this.Name = name;
            this.Address = address;
            this.AccountNumber = accountNumber;
        }
    }
}
