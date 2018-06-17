using AutoMapper;
using BorrowMe.Application.Interface;
using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
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
    public class GamesController : Controller
    {
        private readonly IGameAppService _gameAppRepository;
        private readonly IUserAppService _userAppRepository;
        private readonly IBorrowAppService _borrowAppRepository;
        private readonly SessionContext _context;



        public GamesController(IGameAppService gameAppService, IUserAppService userAppService, IBorrowAppService borrowAppService)
        {
            _gameAppRepository = gameAppService;
            _userAppRepository = userAppService;
            _borrowAppRepository = borrowAppService;
            _context = new SessionContext();
        }

        // GET: Games
        public ActionResult Index()
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gameAppRepository.GetAll());
            return View(gamesViewModel);//gamesViewModel);
        }

        // GET: Games/Details/5
        public ActionResult Details(long id)
        {
            var gameViewModel = Mapper.Map<Game, GameViewModel>(_gameAppRepository.GetById(id));
            return View(gameViewModel);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_userAppRepository.GetAll(), "Id", "Name", _context.GetUserData().Id);
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(GameViewModel game)
        {

            if (ModelState.IsValid)
            {
                var gameDomain = Mapper.Map<GameViewModel, Game>(game);
                _gameAppRepository.Add(gameDomain);

                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(long id)
        {
            var gameViewModel = Mapper.Map<Game, GameViewModel>(_gameAppRepository.GetById(id));
            ViewBag.UserId = new SelectList(_userAppRepository.GetAll(), "Id", "Name", gameViewModel.UserId);
            return View(gameViewModel);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                var gameDomain = Mapper.Map<GameViewModel, Game>(game);
                _gameAppRepository.Update(gameDomain);

                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Delete
        public ActionResult Delete(long id)
        {
            var gameViewModel = Mapper.Map<Game, GameViewModel>(_gameAppRepository.GetById(id));
            return View(gameViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(long id)
        {
            var gameModel = Mapper.Map<Game, GameViewModel>(_gameAppRepository.GetById(id));
            if (ValidateDelete(gameModel))
            {
                var gameViewModel = _gameAppRepository.GetById(id);
                _gameAppRepository.Remove(gameViewModel);
                return RedirectToAction("Index");
            }

            return View(gameModel);
        }        

        public ActionResult ActivesGame()
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>( _gameAppRepository.GameActived(_gameAppRepository.GetAll()));
            return View("Index",gamesViewModel);
        }

        public ActionResult MyGames()
        {
            var userLogged = _context.GetUserData().Id;
            ViewBag.UserLogged = userLogged;
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gameAppRepository.MyGames(userLogged));
            return View("Index", gamesViewModel);
        }

        public ActionResult GameAvailable()
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gameAppRepository.GameAvailable(_gameAppRepository.GetAll()));
            return View("Index", gamesViewModel);
        }

        public ActionResult UnavailablesGame()
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gameAppRepository.GameUnavailable(_gameAppRepository.GetAll()));
            return View("Index", gamesViewModel);
        }

        public ActionResult SearchByTitle(string texto)
        {
            ViewBag.UserLogged = _context.GetUserData().Id;
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gameAppRepository.FindByTitle(texto));
            return View("Index", gamesViewModel);
        }

        public bool ValidateDelete(GameViewModel game)
        {
            var borrow = _borrowAppRepository.BorrowsByGame(game.Id);

            if(borrow != null)
            {
               ModelState.AddModelError(string.Empty,"Esse jogo possui emprestimos, não pode ser excluido.");
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
