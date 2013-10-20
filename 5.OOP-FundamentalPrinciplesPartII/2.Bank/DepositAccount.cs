using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public class DepositAccount : Account
    {
        public DepositAccount(Client customer, double balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public void Withdraw(double moneyToBeWithdrawed)
        {
            this.Balance -= moneyToBeWithdrawed;
        }

        public override double CalcInterestAmount(int numberOfMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
                return base.CalcInterestAmount(numberOfMonths);
        }
    }
}
