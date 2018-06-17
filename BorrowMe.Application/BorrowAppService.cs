using System.Collections.Generic;
using BorrowMe.Application.Interface;
using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Services;
using BorrowMe.Domain.Services;

namespace BorrowMe.Application
{

    public class BorrowAppService : AppServiceBase<Borrow>, IBorrowAppService
    {
        private readonly BorrowService _borrowAppService;

        public BorrowAppService(BorrowService borrowService) : base(borrowService)
        {
            _borrowAppService = borrowService;
        }

        public IEnumerable<Borrow> BorrowsByGame(long id)
        {
            return _borrowAppService.BorrowsByGame(id);
        }

        public IEnumerable<Borrow> BorrowsByUser(long id)
        {
            return _borrowAppService.BorrowsByUser(id);
        }

        public void ReturnBorrow(long id)
        {
            _borrowAppService.ReturnBorrow(id);
        }
    }
}
