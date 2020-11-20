using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Eksamen
{
    public class User : IComparable<User>
    {
        public int ID { get; set; }
        private string _firstName;

        public string FirstName
        {
            get { return _lastName; }
            set
            {
                if (value != null)
                {
                    _lastName = value;
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
            }
        }

        private string _username;
        //TODO LÆR REGEX
        public string Username
        {
            get { return _username; }
            set {}
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    email = value;
                }
                else
                {
                    throw new InvalidDataException("Not a valid email");
                }

            }
        }

        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance += value;
                if (_balance <= 50)
                {
                    //TODO DELIGATE MED NOTIFICATION
                }
            }
        }


        private User()
        {
            
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
