using System;
using System.Collections.Generic;
using namelychat.Models;

namespace namelychat.Services.Users
{
    public interface IUserInterface
    {
        User CreateUser(User user);

        IEnumerable<User> GetUsers();
    }
}
