using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.IO;
using Eksamen.Core;

namespace Tests
{
    public class UserTests
    {
        public List<User> UserList;

        [SetUp]
        public void Setup()
        {
        }

        #region ID
        [Test]
        public void CreateUser_10UsersAreCreated_NoIDsAreTheSame() 
        {
            //Arrange
            UserList = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                UserList.Add(new User("name", "last name", "username", "user@email.com", 500));
            }

            bool UsersWithIdenticalIDs = false;

            //Act
            for (int i = 0; i < UserList.Count; i++)
            {
                List<User> occurrenceList = UserList.FindAll(x => x.ID == UserList[i].ID);
                if (occurrenceList.Count != 1)
                {
                    UsersWithIdenticalIDs = true;
                    break;
                }
            }

            //Assert
            Assert.IsFalse(UsersWithIdenticalIDs);
        }

        [Test]
        public void CreateUser_10UsersAreCreated_IDsGoFromOneToTen()
        {
            //Arrange
            UserList = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                UserList.Add(new User("name", "last name", "username", "user@email.com", 500));
            }

            bool IDsGoFromOneToTen = true;

            //Act
            for (int i = 1; i <= UserList.Count; i++)
            {
                if (UserList[i - 1].ID != i)
                {
                    IDsGoFromOneToTen = false;
                    break;
                }
            }

            //Assert
            Assert.IsTrue(IDsGoFromOneToTen);
        }

        [Test]
        public void CreateUser_ExcistingUserIsAdded_IDsAreStillUnique()
        {
            //Arrange
            User userA = new User("name", "last name", "username", "user@email.com", 500);

            User userB = new User("name", "last name", "username", "user@email.com", 500);

            User userC = new User("name", "last name", "username", "user@email.com", 500);

            //Act 
            bool AIsSmallerThanB = (userA.ID < userB.ID);
            bool CIsBPlusOne = (userC.ID == userB.ID + 1);

            //Assert
            Assert.IsTrue(AIsSmallerThanB && CIsBPlusOne);
        }

        //TODO Hvad sker der hvis man forsøger at assigne et ID som er 'taget'?
        #endregion ID

        #region First name + Last name
        [Test]
        public void CreateUser_FirstNameIsNull_NullExceptionIsThrown()
        {
            //Arrage //Act //Assert
            Assert.Throws<InvalidDataException>(() => new User(null, "last name", "username", "user@email.com", 500));
        }
        
        [Test]
        public void CreateUser_LastNameIsNull_NullExceptionIsThrown()
        {
            //Arrange //Act //Assert
            Assert.Throws<InvalidDataException>(() => new User("firstname", null, "username", "user@email.com", 500));
        }
        #endregion First name

        #region Valid username (function is private, but is tested through the set'er)
        [Test]
        [TestCase("user")]
        [TestCase("42069")]
        [TestCase("_slayer_")]
        public void ValidUsername_UsernameIsValid_UsernameIsSet(string username) 
        {
            //Arrange //Act
            User user = new User("first naem", "last name", username, "email@domain.com", 500);

            //Assert
            Assert.IsTrue(user.Username == username);
        }

        [Test]
        [TestCase("!Bang!")]
        [TestCase("..noice")]
        [TestCase(" ")]
        public void ValidUsername_UsernameIsInvalid_UsernameIsNull(string username)
        {
            //Assert //Arrange //Act
            Assert.Throws<InvalidDataException>((() => new User("first name", "last name", username, "email@domain.com", 500)));
        }
        #endregion Valid username

        #region Valid EMail (function is private, but is tested through the set'er)
        [Test]
        [TestCase("eksempel@domain.dk")]
        [TestCase("42069@x.x-x.com")]
        [TestCase("._-@mail.com")]
        public void ValidEMail_EMailIsVaid_EMailIsSet(string eMail)
        {
            //Arrange //Act
            User user = new User("username", "last name", "username", eMail, 500);

            //Assert
            Assert.IsTrue(user.Email == eMail);
        }

        [Test]
        [TestCase("eksempel(2)@-mit_domain.dk")]
        [TestCase("userAcom")]
        [TestCase("user@mailcom")]
        [TestCase("user@_mail_.com")]
        public void ValidEMail_EMailIsInvaid_EMailIsSet(string eMail)
        {
            //Arrange //Act

            //Assert
            Assert.Throws<InvalidDataException>(() => new User("username", "last name", "username", eMail, 500));
        }
        #endregion Valid EMail
        //TODO evt test .CompareTo() og .Equals()
    }

}