using BorrowMe.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BorrowMe.Infra.Data.EntityConfig
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.Id);
            
            Property(x => x.UserName)
                .IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));
        }
    }
}
