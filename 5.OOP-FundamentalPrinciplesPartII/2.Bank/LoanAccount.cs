using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public class LoanAccount : Account
    {
        public LoanAccount(Client customer, double balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public override double CalcInterestAmount(int numberOfMonths)
        {
            if (this.Customer is Individual)
            {
                return (numberOfMonths - 3) * this.InterestRate;
            }
            else
            {
                return (numberOfMonths - 2) * this.InterestRate;
            }
        }
    }
}
