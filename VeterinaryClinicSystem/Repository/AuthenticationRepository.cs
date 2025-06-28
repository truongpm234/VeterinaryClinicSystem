using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public User GetUserById(int id) => Authentication.GetUserById(id);
        public User GetUserByEmail(string email) => Authentication.GetUserByEmail(email);

        public void CreateUser(User user) => Authentication.CreateUser(user);
        public bool IsEmailExists(string email) => Authentication.IsEmailExists(email);
    }
}
