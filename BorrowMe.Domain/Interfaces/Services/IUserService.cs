using BorrowMe.Domain.Entities;

namespace BorrowMe.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User Login(string name, string password);
        bool UserNameValidate(string userName);
    }
}
