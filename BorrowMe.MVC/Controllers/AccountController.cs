using AutoMapper;
using BorrowMe.Application.Interface;
using BorrowMe.Domain.Entities;
using BorrowMe.MVC.Utils;
using BorrowMe.MVC.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace BorrowMe.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly SessionContext context;

        public AccountController(IUserAppService userAppService)
        {
            context = new SessionContext();
            _userAppService = userAppService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            var hash = new Helpers.Cript();

            var authenticatedUser = _userAppService.Login(user.UserName, hash.GenerateSHA512String(user.Password));
            if (authenticatedUser != null)
            {
                var userAuth = PopuleUserLoginAuth(authenticatedUser);
                context.SetAuthenticationToken(authenticatedUser.Name.ToString(), false, userAuth);
                return RedirectToAction("Index", "Home");
            }
            else
            {
               ModelState.AddModelError(string.Empty, "Usuário ou senha inválido");
            }

            return View(user);
        }        

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
                
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Register(UserViewModel user)
        {

            if (ModelState.IsValid && UserValidate(user))
            {
                var hash = new Helpers.Cript();
                user.Password = hash.GenerateSHA512String(user.Password);
                var userModel = Mapper.Map<UserViewModel, User>(user);
                _userAppService.Add(userModel);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        public bool UserValidate(UserViewModel user)
        {
            if (_userAppService.UserNameValidate(user.UserName))
            {
                ModelState.AddModelError("UserName", "Usuário já cadastrado.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Popula o model UserAuthViewModel para inserir na sessao de login
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Retorna um objeto do tipo UserAuthViewModel</returns>
        public UserAuthViewModel PopuleUserLoginAuth(User user)
        {
            var userAuth = new UserAuthViewModel();
            userAuth.Id = user.Id;
            userAuth.Name = user.Name;
            userAuth.UserName = user.UserName;

            return userAuth;
        }
    }
}
