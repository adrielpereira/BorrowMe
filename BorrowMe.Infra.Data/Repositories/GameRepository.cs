using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BorrowMe.Infra.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public void BorrowGame(long id)
        {
            Db.Games.Find(id).IsBorrowed = true;
            Db.SaveChanges();
        }

        public void ReturnGame(long id)
        {
            Db.Games.Find(id).IsBorrowed = false;
            Db.SaveChanges();
        }

        public IEnumerable<Game> FindByTitle(string title)
        {
            var games = Db.Games.Where(x => x.Title.Contains(title)).ToList();

            if (games != null)
                return games;
            else
                return null;
        }

        public IEnumerable<Game> GameActived(IEnumerable<Game> games)
        {
            return games.Where(g => g.GameActived(g));
        }

        public IEnumerable<Game> GameAvailable(IEnumerable<Game> games)
        {
            return games.Where(g => g.GameAvailable(g));
        }

        public IEnumerable<Game> GameUnavailable(IEnumerable<Game> games)
        {
            return games.Where(g => g.GameUnavailable(g));
        }

        public IEnumerable<Game> MyGames(long id)
        {
            return Db.Games.Where(x => x.UserId == id).ToList(); 
        }
    }
}
