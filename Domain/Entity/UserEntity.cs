using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserEntity
    {
        public UserEntity(string username, string password, string email, int userType)
        {
            Username = username;
            Password = password;
            Email = email;
            UserType = userType;
        }

        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int UserType { get; private set; } // UserRoleEnum : 0 admin, 1 user
    }
}