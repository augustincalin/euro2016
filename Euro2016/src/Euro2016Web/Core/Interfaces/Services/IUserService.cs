using Euro2016Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.Core.Interfaces.Services
{
    public interface IUserService
    {
        User GetUserByName(string username);
        ICollection<User> GetTop(int number);
        User Add(string username);
    }
}
