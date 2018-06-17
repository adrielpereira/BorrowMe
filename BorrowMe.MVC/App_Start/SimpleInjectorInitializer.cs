using BorrowMe.Infra.CrossCutting.IoC;
using BorrowMe.MVC.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace BorrowMe.MVC.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            // Simple Injector Modules
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}