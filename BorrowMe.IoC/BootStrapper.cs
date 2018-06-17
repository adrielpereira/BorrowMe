using BorrowMe.Application;
using BorrowMe.Application.Interface;
using BorrowMe.Domain.Interfaces.Repositories;
using BorrowMe.Domain.Interfaces.Services;
using BorrowMe.Domain.Services;
using BorrowMe.Infra.Data.Repositories;
using SimpleInjector;

namespace BorrowMe.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            container.Register<IUserAppService, UserAppService>(); 
            container.Register<IGameAppService, GameAppService>();
            container.Register<IBorrowAppService, BorrowAppService>();


            container.Register<IUserService, UserService>();
            container.Register<IGameService, GameService>();
            container.Register<IBorrowService, BorrowService>();


            container.Register<IUserRepository, UserRepository>();
            container.Register<IGameRepository, GameRepository>();
            container.Register<IBorrowRepository, BorrowRepository>();

        }
    }
}
