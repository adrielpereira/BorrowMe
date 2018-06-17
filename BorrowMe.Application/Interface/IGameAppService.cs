using BorrowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowMe.Application.Interface
{
    public interface IGameAppService : IAppServiceBase<Game>
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
