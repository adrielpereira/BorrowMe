using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using BorrowMe.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace BorrowMe.Domain.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository) 
            : base(gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void BorrowGame(long id)
        {
            _gameRepository.BorrowGame(id);
        }

        public IEnumerable<Game> FindByTitle(string title)
        {
           return  _gameRepository.FindByTitle(title);
        }

        public IEnumerable<Game> GameActived(IEnumerable<Game> games)
        {
            return _gameRepository.GameActived(games);
        }

        public IEnumerable<Game> GameAvailable(IEnumerable<Game> games)
        {
            return _gameRepository.GameAvailable(games);
        }

        public IEnumerable<Game> GameUnavailable(IEnumerable<Game> games)
        {
            return _gameRepository.GameUnavailable(games);
        }

        public IEnumerable<Game> MyGames(long id)
        {
            return _gameRepository.MyGames(id);
        }

        public void ReturnGame(long id)
        {
            _gameRepository.ReturnGame(id);
        }
    }
}
