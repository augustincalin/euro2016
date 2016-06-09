using Euro2016Web.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euro2016Web.Core.Model;
using Euro2016Web.Core.Interfaces;

namespace Euro2016Web.Core.Services
{
    public class UserService : IUserService
    {
        protected readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(string username)
        {
            User user = new User
            {
                Username = username,
                TotalPoints = 0
            };
            _userRepository.Add(user);
            _userRepository.Save();
            return user;
        }

        public ICollection<User> GetTop(int number)
        {
            return _userRepository.GetAll().OrderByDescending(u => u.TotalPoints).Take(number).ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepository.SingleOrDefault(u => u.Id == id);
        }

        public User GetUserByName(string username)
        {
            return _userRepository.SingleOrDefault(u => u.Username == username);
        }

        public User UpdateName(string userName, string name)
        {
            User user = GetUserByName(userName);
            if(null != user)
            {
                user.FriendlyUsername = name;
                _userRepository.Save();
            }
            return user;
        }
    }
}
