using BorrowMe.Domain.Entities;
using System.Collections.Generic;

namespace BorrowMe.Domain.Interfaces.Repositories
{
    public interface IBorrowRepository : IRepositoryBase<Borrow>
    {
        void ReturnBorrow(long id);

        IEnumerable<Borrow> BorrowsByGame(long id);

        IEnumerable<Borrow> BorrowsByUser(long id);

    }
}
