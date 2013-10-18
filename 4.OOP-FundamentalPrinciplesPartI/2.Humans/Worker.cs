using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Humans
{
    public class Worker : Human
    {
        public double WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            return (double)(WeekSalary / (5 * WorkHoursPerDay));
        }
    }
}
