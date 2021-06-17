using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntakeApp.Classes
{
	public class User
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private int userPoints;

        public User(int _userId, string _firstname, string _lastname, string _userName, string _password, int _userPoints)
        {
            this.userId = _userId;
            this.firstName = _firstname;
            this.lastName = _lastname;
            this.userName = _userName;
            this.password = _password;
            this.userPoints = _userPoints;
        }

        public int GetId()
        {
            return userId;
        }
        public string GetFirst()
        {
            return firstName;
        }
        public string GetLast()
        {
            return lastName;
        }
        public string GetUserName()
        {
            return userName;
        }
        public string GetPassword()
        {
            return password;
        }

        public int GetPoints()
        {
            return userPoints;
        }

        public void SetPoints(int points)
        {
            this.userPoints = points;
        }
    }
}
