using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using BorrowMe.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BorrowMe.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string name, string password)
        {
            return _userRepository.Login(name, password);
        }

        public bool UserNameValidate(string userName)
        {
            return _userRepository.UserNameValidate(userName);
        }
    }
}


