using System.Data.Entity;
using System.Linq;
using DBModelLib.Entities;
using DBModelLib.Views;

namespace Dal.Context
{
    public class LittleHelperContext : DbContext, ILittleHelperContext
    {
        public LittleHelperContext() : base("name=LittleHelperContext")
        {
           // Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<FoodSort> FoodSort { get; set; }
        public virtual DbSet<Inventar> Inventar { get; set; }
        public virtual DbSet<Messurement> Messurement { get; set; }
        public virtual DbSet<User> User { get; set; }

        // Views
        public virtual DbSet<InventarView> InventarView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tables for the survey schema
            modelBuilder.HasDefaultSchema("LHELP");
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<FoodSort>().ToTable("FoodSort");
            modelBuilder.Entity<Inventar>().ToTable("Inventar");
            modelBuilder.Entity<Messurement>().ToTable("Messurement");
            modelBuilder.Entity<User>().ToTable("User");
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            // For debugging and audit
            var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
            var addedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Added).ToList();
            var deletedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();

            return base.SaveChanges();
        }

    }
}