using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public abstract class Client
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long AccountNumber { get; set; }

        //public Client(string name, string address, long accountNumber)
        //{
        //    this.name = name;
        //    this.address = address;
        //    this.accountNumber = accountNumber;
        //}

        //public Client(string name, long accountNumber)
        //    : this(name, "", accountNumber)
        //{
        //}
        //public Client(string name)
        //    : this(name, "", 0)
        //{
        //}

        //public string Name
        //{
        //    get { return this.name; }
        //    set { this.name = name; }
        //}

        //public string Address
        //{
        //    get { return this.address; }
        //    set { this.address = value; }
        //}

        //public long AccountNumber
        //{
        //    get { return this.accountNumber; }
        //    set { this.accountNumber = value; }
        //}
    }
}
