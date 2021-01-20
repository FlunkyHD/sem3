using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Eksamen.Core
{
    public class User : IComparable<User>
    {
        //Used locally in the comapre function
        private User()
        {

        }
        //Used when reading the file
        public User(string line)
        {
            string[] split = line.Split(',');
            ID = Convert.ToInt32(split[0]);
            FirstName = Convert.ToString(split[1]);
            LastName = Convert.ToString(split[2]);
            Username = Convert.ToString(split[3]);
            Balance = (Convert.ToDecimal(split[4])) / 100; //To DDK
            Email = Convert.ToString(split[5]);

            if (ID > idCounter) //If users later are craeted manually, to make sure there are no overlaps
            {
                idCounter = ID;
            }
        }
        public User(string firstname, string lastname, string username, string email, decimal balance)
        {
            ID = _id;
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Email = email;
            Balance = balance;
        }

        private static int idCounter = 0; //To get unique id´s
        private readonly int _id = ++idCounter;
        public int ID { get; }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != null)
                {
                    _firstName = value;
                }
                else
                {
                    throw new InvalidDataException($"Invalid firstname {value}");
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != null)
                {
                    _lastName = value;
                }
                else
                {
                    throw new InvalidDataException($"Invalid lastname: {value}");
                }
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-z0-9+_]+$"))
                {
                    _username = value;
                }
                else
                {
                    throw new InvalidDataException($"Invalid username: {value}");
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (!value.Contains('@'))
                {
                    throw new InvalidDataException($"Invalid email: {value}");
                }
                string[] split = value.Split('@');
                if (Regex.IsMatch(split[0], @"^[a-zA-Z0-9+_\.-]") && Regex.IsMatch(split[1], @"^(?!\.|-)[a-zA-Z0-9.-]+[^.-]$") && split[1].Contains('.'))
                {
                    _email = value;
                }
                else
                {
                    throw new InvalidDataException($"Invalid email: {value}");
                }
            }
        }

        public decimal Balance { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Email})";
        }

        public int CompareTo(User other)
        {
            if (this.ID > other.ID)
            {
                return 1;
            } 
            else if (this.ID < other.ID)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override bool Equals(object? obj)
        {
            User equl;
            if (obj != null && obj is User)
            {
                equl = (User) obj;
            }
            else
            {
                return false;
            }

            if (this.GetHashCode() == equl.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Needed because of the Equals method
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

    }
}
