using AutoMapper;
using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using BorrowMe.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using BorrowMe.MVC.Helpers;
using BorrowMe.Application.Interface;
using System.Linq;

namespace BorrowMe.MVC.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserAppService _userRepository;
        private readonly IGameAppService _gameAppRepository;
        private readonly IBorrowAppService _borrowAppRepository;

        public UsersController(IUserAppService userAppService, IGameAppService gameAppService, IBorrowAppService borrowAppService )
        {
            _userRepository = userAppService;
            _gameAppRepository = gameAppService;
            _borrowAppRepository = borrowAppService;

        }

        // GET: Users
        public ActionResult Index()
        {
            var users = _userRepository.GetAll();
            var userModels = Mapper.Map<IEnumerable<User>,IEnumerable<UserViewModel>>(users);
            return View(userModels);
        }

        // GET: Users/Details/5
        public ActionResult Details(long id)
        {
            var user = Mapper.Map<User, UserViewModel>(_userRepository.GetById(id));
            return View(user);
        }

        // GET: Users/Delete
        public ActionResult Delete(long id)
        {
            var userViewModel = Mapper.Map<User, UserViewModel>(_userRepository.GetById(id));
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(long id)
        {
            var userViewModel = _userRepository.GetById(id);
            if (userViewModel != null && ValidateDelete(id))
            {
                _userRepository.Remove(userViewModel);
                return RedirectToAction("Index");
            }
             var model = Mapper.Map<User, UserViewModel>(userViewModel);
            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(long id)
        {
            var userViewModel = Mapper.Map<User, UserViewModel>(_userRepository.GetById(id));
            userViewModel.Password = string.Empty;
            return View(userViewModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditViewModel user)
        {
            if (ModelState.IsValid )
            {
                var userModel = _userRepository.GetById(user.Id);
                userModel.IsActive = user.IsActive;
                if (userModel.UserName == user.UserName || (userModel.UserName != user.UserName && UserValidate(user))) {
                    userModel.Name = user.Name;
                    userModel.UserName = user.UserName;

                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        userModel.Password = new Helpers.Cript().GenerateSHA512String(user.Password);
                    }
                    _userRepository.Update(userModel);

                    return RedirectToAction("Index");
                };
            }
            var userViewModel = Mapper.Map<User, UserViewModel>(_userRepository.GetById(user.Id));
            userViewModel.Password = null;

            return View(userViewModel);
        }

        public bool ValidateDelete(long id)
        {
            var games = _gameAppRepository.MyGames(id);
            var borrow = _borrowAppRepository.BorrowsByUser(id);

            if ((games != null && games.Count() > 0) || (borrow != null && borrow.Count() > 0))
            {
                ModelState.AddModelError(string.Empty, "Esse usuário possui jogos ou empréstimos vinculados, não pode ser excluido.");
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool UserValidate(UserEditViewModel user)
        {
            if (_userRepository.UserNameValidate(user.UserName))
            {
                ModelState.AddModelError("UserName", "Usuário já cadastrado.");
                return false;
            }

            return true;
        }
    }
}
