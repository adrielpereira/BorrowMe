using BorrowMe.Domain.Entities;
using System.Collections.Generic;

namespace BorrowMe.Application.Interface
{
    public interface IBorrowAppService : IAppServiceBase<Borrow>
    {
        void ReturnBorrow(long id);

        IEnumerable<Borrow> BorrowsByGame(long id);

        IEnumerable<Borrow> BorrowsByUser(long id);
    }
}
