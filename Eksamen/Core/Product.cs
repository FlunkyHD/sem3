using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Eksamen.Core
{
    public class Product
    {
        public Product(string line)
        {
            string[] split = line.Split(';');
            ID = Convert.ToInt32(split[0]);
            Name = Regex.Replace(Convert.ToString(split[1]), "<.*?>", String.Empty).Replace("\"", "");
            Price = (Convert.ToDecimal(split[2])) / 100; //To DDK
            if (Convert.ToInt32(split[3]) == 1)
            {
                Active = true;
            }
            else
            {
                Active = false;
            }

            CanBeBoughtOnCredit = false;
        }
        public Product(int id, string name, decimal price, bool active, bool canBeBoughOnCredit)
        {
            ID = id;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughOnCredit;
        }


        private int _id;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new InvalidDataException($"The product ID has to be 1 or higher! Was given: {value}");
                }
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    throw  new InvalidDataException($"The name can not be {value}");
                }
            }
        }
        public decimal Price { get; set; }

        public bool Active { get; set; }

        public bool CanBeBoughtOnCredit { get; set; }

        public override string ToString()
        {
            return String.Format("{0,-7} {1,-35} {2,7}", $"{ID})", Name, $"{Price}");
        }
    }
}
