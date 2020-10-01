using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion2
{
    class Manager : Employee
    {

        public double Bonus { get; set; }

        public Manager(string name, string jobTitle, double salary, double level, double bonus) : base(name, jobTitle, salary, level)
        {
            Bonus = bonus;
        }

        public override double CalculateYearlySalary()
        {
            return base.CalculateYearlySalary() + Bonus;
        }
    }
}
