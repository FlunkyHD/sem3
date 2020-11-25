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
        public int ID { get; set; }
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
                if (Regex.IsMatch(value, "^[a-z0-9_]+$"))
                {
                    _username = value;
                }
                else
                {
                    throw new InvalidDataException($"Invalid username: {value}"); //TODO LAV EN MED USERS
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (Regex.IsMatch(value, "^(?!\\.|\\-)[a-zA-Z0-9+_\\.\\-]+@[a-zA-Z0-9.-]+[^\\.\\-]$") && value.Contains('.'))
                {
                    _email = value;
                }
                else
                {
                    throw new InvalidDataException($"Invalid email: {value}");
                }
            }
        }

        private decimal _balance;

        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        private User()
        {
            
        }
        public User(string line)
        {
            string[] split = line.Split(',');
            ID = Convert.ToInt32(split[0]);
            FirstName = Convert.ToString(split[1]);
            LastName = Convert.ToString(split[2]);
            Username = Convert.ToString(split[3]);
            Balance = Convert.ToDecimal(split[4]);
            Email = Convert.ToString(split[5]);
        }
        public User(int id, string firstname, string lastname, string username, string email, decimal balance)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Email = email;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}  ({Email})";
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
            User equl = new User();
            if (obj is User)
            {
                equl = (User) obj;
            }
            else
            {
                return false;
            }

            if (this.ID == equl.ID)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

    }
}
