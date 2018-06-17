using BorrowMe.Application.Interface;
using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowMe.Application
{
    public class GameAppService : AppServiceBase<Game>, IGameAppService
    {
        private readonly GameService _gameAppService;

        public GameAppService(GameService gameAppService) : base(gameAppService)
        {
            _gameAppService = gameAppService;
        }

        public void BorrowGame(long id)
        {
            _gameAppService.BorrowGame(id);
        }

        public IEnumerable<Game> FindByTitle(string title)
        {
            return _gameAppService.FindByTitle(title);
        }

        public IEnumerable<Game> GameActived(IEnumerable<Game> games)
        {
            return _gameAppService.GameActived(games);
        }

        public IEnumerable<Game> GameAvailable(IEnumerable<Game> games)
        {
            return _gameAppService.GameAvailable(games);
        }

        public IEnumerable<Game> GameUnavailable(IEnumerable<Game> games)
        {
            return _gameAppService.GameUnavailable(games);
        }

        public IEnumerable<Game> MyGames(long id)
        {
            return _gameAppService.MyGames(id);
        }

        public void ReturnGame(long id)
        {
            _gameAppService.ReturnGame(id);
        }
    }
}
