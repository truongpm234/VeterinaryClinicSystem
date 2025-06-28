using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public User GetUserById(int id) => _authenticationRepository.GetUserById(id);
        public User GetUserByEmail(string email) => _authenticationRepository.GetUserByEmail(email);
        public void CreateUser(User user) => _authenticationRepository.CreateUser(user);
        public bool IsEmailExists(string email) => _authenticationRepository.IsEmailExists(email);
        
    }
}
