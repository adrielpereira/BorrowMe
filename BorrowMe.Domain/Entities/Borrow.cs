using System;

namespace BorrowMe.Domain.Entities
{
    public class Borrow
    {       
        public long Id { get; set; }

        public DateTime BorrowedAt { get; set; }

        public DateTime? ReturnDate { get; set; }

        public long UserId { get; set; }

        public long GameId { get; set; }

        public virtual User User { get; set; }

        public virtual Game Game { get; set; }

    }
}
