using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers() => UserDAO.GetAllUsers();
        public User GetUserById(int id) => UserDAO.GetUserById(id);
        public void CreateUser(User user) => UserDAO.CreateUser(user);
        public void UpdateUser(User user) => UserDAO.UpdateUser(user);
        public void DeleteUser(int id) => UserDAO.DeleteUser(id);
        public void ActiveUser(int activeUser) => UserDAO.ActiveUser(activeUser);

    }
}
