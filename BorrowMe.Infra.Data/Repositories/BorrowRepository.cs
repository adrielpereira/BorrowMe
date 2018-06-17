using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorrowMe.Infra.Data.Repositories
{
    public class BorrowRepository : RepositoryBase<Borrow>, IBorrowRepository
    {
        public IEnumerable<Borrow> BorrowsByGame(long id)
        {
            var borrow = Db.Borrows.Where(x => x.GameId == id).ToList();
            if (borrow != null)
                return borrow;
            else
                return null;
        }

        public IEnumerable<Borrow> BorrowsByUser(long id)
        {
            var borrow = Db.Borrows.Where(x => x.UserId == id).ToList();
            if (borrow != null)
                return borrow;
            else
                return null;
        }

        public void ReturnBorrow(long id)
        {
            Db.Borrows.Find(id).ReturnDate = DateTime.Now;
            Db.SaveChanges();
        }
    }
}
