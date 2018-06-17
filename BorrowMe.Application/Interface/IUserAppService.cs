using BorrowMe.Domain.Entities;

namespace BorrowMe.Application.Interface
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        User Login(string name, string password);

        bool UserNameValidate(string userName);
    }
}
