using System;
using System.Collections.Generic;

namespace BorrowMe.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        
    }
}
