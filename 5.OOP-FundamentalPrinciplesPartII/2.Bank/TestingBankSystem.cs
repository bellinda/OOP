using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public class TestingBankSystem
    {
        static void Main()
        {
            Account[] accounts = new Account[]
            {
                new DepositAccount(new Individual("Petar Nikolov"), 1320.50, 0.5),
                new LoanAccount(new Company("Akula OOD", 10050214), 2000, 1.7),
                new MortgageAccount(new Individual("Kameliya Yordanova"), 210.05, 1.3),
                new DepositAccount(new Company("MarinaTrade", 30021020, "Sofia City, Bulv.Tsarigradsko shose, 115"), 1402.67, 3.5),
                new MortgageAccount(new Company("DespicableUs", 50014435, "Varna, 9000, \"Khan Asparuh\"Str. Nr21"), 570.50, 4.0),
                new LoanAccount(new Individual("Aleksander Milushev", 20030060), 654, 1.8)
            };

            foreach (Account account in accounts)
            {
                account.Deposit(300);
                Console.WriteLine("{0}: customer - {1}, balance = {2}lv, interest for an year:{3}lv", account.GetType().Name, account.Customer.GetType().Name, account.Balance, account.CalcInterestAmount(12));
            }
            DepositAccount newAccount = new DepositAccount(new Individual("Stanka Murdzeva"), 500, 1.9);
            newAccount.Withdraw(200.50);
            Console.WriteLine("{0}: customer - {1}, balance = {2}lv, interest for an year:{3}lv", newAccount.GetType().Name, newAccount.Customer.GetType().Name, newAccount.Balance, newAccount.CalcInterestAmount(12));
        }
    }
}
