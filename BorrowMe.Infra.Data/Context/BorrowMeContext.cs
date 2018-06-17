using BorrowMe.Domain.Entities;
using BorrowMe.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace BorrowMe.Infra.Data.Context
{
    public class BorrowMeContext : DbContext
    {
        public BorrowMeContext()
        : base("BorrowMeCS")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new BorrowConfiguration());

            base.OnModelCreating(modelBuilder);
        }        

        public override int SaveChanges()
        {
            foreach (var e in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (e.State == EntityState.Added)
                    e.Property("CreatedAt").CurrentValue = DateTime.Now;
                if (e.State == EntityState.Modified)
                    e.Property("CreatedAt").IsModified = false;
            }

            foreach (var e in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("BorrowedAt") != null))
            {
                if (e.State == EntityState.Added)
                    e.Property("BorrowedAt").CurrentValue = DateTime.Now;
                if (e.State == EntityState.Modified)
                    e.Property("BorrowedAt").IsModified = false;
            }

            return base.SaveChanges();
        }
    }

    
}
