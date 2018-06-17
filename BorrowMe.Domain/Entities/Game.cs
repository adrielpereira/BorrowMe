using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowMe.Domain.Entities
{
    public class Game
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public bool IsBorrowed { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public bool GameAvailable(Game game)
        {
            return game.IsBorrowed == false;
        }

        public bool GameUnavailable(Game game)
        {
            return game.IsBorrowed == true;
        }

        public bool GameActived(Game game)
        {
            return game.IsActive == true;
        }
        
    }
}
