using BorrowMe.Application.Interface;
using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Services;
using BorrowMe.Domain.Services;

namespace BorrowMe.Application
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userAppService;

        public UserAppService(IUserService userAppService) : base(userAppService)
        {
            _userAppService = userAppService;
        }

        public User Login(string name, string password)
        {
            return _userAppService.Login(name, password);
        }

        public bool UserNameValidate(string userName)
        {
            return _userAppService.UserNameValidate(userName);
        }
    }
}
