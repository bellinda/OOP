using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public abstract class Account
    {
        public Client Customer { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }

        public virtual double CalcInterestAmount(int numberOfMonths)
        {
            return numberOfMonths * this.InterestRate;
        }

        public void Deposit(double moneyToBeDeposited)
        {
            this.Balance += moneyToBeDeposited;
        }
    }
}
