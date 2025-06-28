using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAuthenticationService
    {
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void CreateUser(User user);
        bool IsEmailExists(string email);

    }
}
