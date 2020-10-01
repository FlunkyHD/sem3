using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion2
{
    class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        private double _salary { get; set; }
        private double _seneniorityLevel { get; set; }

        public Employee(string name, string jobTitle, double salary, double level)
        {
            Name = name;
            JobTitle = jobTitle;
            _salary = salary;
            _seneniorityLevel = level;
        }

        public virtual double CalculateYearlySalary()
        {
            return (_salary * 12) * (1 + (_seneniorityLevel / 10));
        }


    }
}
