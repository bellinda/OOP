using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Client customer, double balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public override double CalcInterestAmount(int numberOfMonths)
        {
            if (numberOfMonths <= 12 && this.Customer is Company)
            {
                return numberOfMonths * (this.InterestRate / 2);
            }
            else if (this.Customer is Individual && numberOfMonths <= 6)
            {
                return 0;
            }
            else
                return numberOfMonths * this.InterestRate;
        }
    }
}
