using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen
{
    public class User : IComparable<User>
    {
        public int ID { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        private decimal _balance { get; set; }


        private User()
        {
            
        }
        public User(int id, string firstname, string lastname, string username, string email, decimal blance)
        {
            ID = id;
            firstName = firstname;
            lastName = lastname;
            Username = username;
            Email = email;
            _balance = _balance;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}  ({Email})";
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
