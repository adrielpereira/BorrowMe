using BorrowMe.Domain.Entities;
using System.Collections.Generic;

namespace BorrowMe.Domain.Interfaces.Services
{
    public interface IGameService : IServiceBase<Game>
    {
        IEnumerable<Game> FindByTitle(string title);

        IEnumerable<Game> MyGames(long id);

        IEnumerable<Game> GameAvailable(IEnumerable<Game> games);

        IEnumerable<Game> GameUnavailable(IEnumerable<Game> games);

        IEnumerable<Game> GameActived(IEnumerable<Game> games);

        void BorrowGame(long id);

        void ReturnGame(long id);
    }
}
