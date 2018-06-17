using BorrowMe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BorrowMe.Infra.Data.EntityConfig
{
    public class BorrowConfiguration : EntityTypeConfiguration<Borrow>
    {
        public BorrowConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
