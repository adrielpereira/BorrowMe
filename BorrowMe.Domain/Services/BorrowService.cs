using System.Collections.Generic;
using BorrowMe.Domain.Entities;
using BorrowMe.Domain.Interfaces.Repositories;
using BorrowMe.Domain.Interfaces.Services;

namespace BorrowMe.Domain.Services
{
    public class BorrowService : ServiceBase<Borrow>, IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;

        public BorrowService(IBorrowRepository borrowRepository)
            : base(borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public IEnumerable<Borrow> BorrowsByGame(long id)
        {
            return _borrowRepository.BorrowsByGame(id);
        }

        public IEnumerable<Borrow> BorrowsByUser(long id)
        {
            return _borrowRepository.BorrowsByUser(id);
        }

        public void ReturnBorrow(long id)
        {
            _borrowRepository.ReturnBorrow(id);
        }
    }
}
