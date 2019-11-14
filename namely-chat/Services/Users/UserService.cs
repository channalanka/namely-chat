using System;
using System.Collections.Generic;
using namelychat.AuthSecurity;
using namelychat.Models;

namespace namelychat.Services.Users
{
    public class UserService: IUserInterface
    {
        IEnumerable<User> _users;
        ISecurityService _securityService;
        public UserService(ISecurityService securityService)
        {
            this._securityService = securityService;
            this._users = new List<User>();
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
