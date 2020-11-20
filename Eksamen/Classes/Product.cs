using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Eksamen
{
    public class Product
    {
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
                    throw new InvalidDataException("The product ID has to be 1 or higher");
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
                    throw  new InvalidDataException("The name can not be null");
                }
            }
        }

        private decimal _price;
        public decimal Price { get; set; }

        private bool _active;
        public bool Active { get; set; }

        private bool _canBeOutOfCredit;
        public bool CanBeBoughtOnCredit { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}: {Price}";
        }
    }
}
