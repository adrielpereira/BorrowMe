using AutoMapper;
using BorrowMe.Application.Interface;
using BorrowMe.Domain.Entities;
using BorrowMe.MVC.Utils;
using BorrowMe.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BorrowMe.MVC.Controllers
{

    [Authorize]
    public class BorrowsController : Controller
    {
        private readonly IGameAppService _gameAppRepository;
        private readonly IUserAppService _userAppRepository;
        private readonly IBorrowAppService _borrowAppRepository;
        private readonly SessionContext _context;

        public BorrowsController(IGameAppService gameAppService, IUserAppService userAppService, IBorrowAppService borrowAppService)
        {
            _gameAppRepository = gameAppService;
            _userAppRepository = userAppService;
            _borrowAppRepository = borrowAppService;
            _context = new SessionContext();
        }

        // GET: Borrows
        public ActionResult Index()
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var borrowsViewModel = Mapper.Map<IEnumerable<Borrow>, IEnumerable<BorrowViewModel>>(_borrowAppRepository.GetAll());
            return View(borrowsViewModel);
        }

        public ActionResult MyBorrows()
        {
            long userId = _context.GetUserData().Id;
            ViewBag.UserLogged = userId;
            var borrowsViewModel = Mapper.Map<IEnumerable<Borrow>, IEnumerable<BorrowViewModel>>(_borrowAppRepository.BorrowsByUser(userId));
            return View("Index",borrowsViewModel);
        }

        public ActionResult BorrowsByGame(long id)
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var borrowsViewModel = Mapper.Map<IEnumerable<Borrow>, IEnumerable<BorrowViewModel>>(_borrowAppRepository.BorrowsByGame(id));
            return View("Index",borrowsViewModel);
        }

        // GET: Borrows/Details/5
        public ActionResult Details(int id)
        {
            var borrowViewModel = Mapper.Map<Borrow, BorrowViewModel>(_borrowAppRepository.GetById(id));
            return View(borrowViewModel);
        }

        // GET: Borrows/Create
        public ActionResult Create(int id)
        {
            var gameViewModel = Mapper.Map<Game, GameViewModel>(_gameAppRepository.GetById(id));

            ViewBag.User = gameViewModel.User.Name;
            ViewBag.Game = gameViewModel.Title;
            ViewBag.GameId = id;

            return View();
        }

        // POST: Borrows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BorrowViewModel borrow)
        {
            if (ModelState.IsValid)
            {
                var user = _context.GetUserData();
                borrow.Id = 0;
                borrow.UserId = user.Id;
                var borrowModel = Mapper.Map<BorrowViewModel, Borrow>(borrow);
                _borrowAppRepository.Add(borrowModel);
                _gameAppRepository.BorrowGame(borrowModel.GameId);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Borrows/Delete/5
        public ActionResult Delete(int id)
        {
            var borrow = Mapper.Map<Borrow, BorrowViewModel>(_borrowAppRepository.GetById(id));
            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var borrowViewModel = _borrowAppRepository.GetById(id);
            if (borrowViewModel != null)
            {
                _borrowAppRepository.Remove(borrowViewModel);
                return RedirectToAction("Index");
            }
            var borrow = Mapper.Map<Borrow, BorrowViewModel>(borrowViewModel);
            return View(borrow);
        }

        public ActionResult ReturnBorrow(int id)
        {
            var borrowViewModel = Mapper.Map<Borrow, BorrowViewModel>(_borrowAppRepository.GetById(id));
            return View(borrowViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ReturnBorrow")]
        public ActionResult ReturnBorrowGame(int id)
        {
            if (ModelState.IsValid)
            {
                var borrowModel = _borrowAppRepository.GetById(id);
                _borrowAppRepository.ReturnBorrow(borrowModel.Id);
                _gameAppRepository.ReturnGame(borrowModel.GameId);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
