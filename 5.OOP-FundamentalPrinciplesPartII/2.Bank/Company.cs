using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public class Company : Client
    {
        public Company(string name)
            : this(name, 0, "")
        {
        }

        public Company(string name, long accountNumber)
            : this(name, accountNumber, "")
        {
        }

        public Company(string name, long accountNumber, string address)
        {
            this.Name = name;
            this.Address = address;
            this.AccountNumber = accountNumber;
        }
    }
}
