using BorrowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowMe.Infra.Data.EntityConfig
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            HasKey(x => x.Id);
            
            Property(x => x.Title)
                .IsRequired();
            
        }
    }
}
