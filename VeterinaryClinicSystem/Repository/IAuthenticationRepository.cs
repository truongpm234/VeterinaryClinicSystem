using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repository
{
    public interface IAuthenticationRepository
    {
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void CreateUser(User user);
        bool IsEmailExists(string email);
    }
}
