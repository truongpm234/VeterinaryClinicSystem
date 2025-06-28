using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers() => _userRepository.GetAllUsers();
        public User GetUserById(int id) => _userRepository.GetUserById(id);
        public void CreateUser(User user) => _userRepository.CreateUser(user);
        public void UpdateUser(User user) => _userRepository.UpdateUser(user);
        public void DeleteUser(int id) => _userRepository.DeleteUser(id);
        public void ActiveUser(int activeUser) => _userRepository.ActiveUser(activeUser);
    }
}
