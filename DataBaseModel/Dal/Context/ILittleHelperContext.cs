using System.Data.Entity;
using DBModelLib.Entities;
using DBModelLib.Views;

namespace Dal.Context
{
    public interface ILittleHelperContext
    {
        DbSet<Food> Food { get; set; }
        DbSet<FoodSort> FoodSort { get; set; }
        DbSet<Inventar> Inventar { get; set; }
        DbSet<Messurement> Messurement { get; set; }
        DbSet<User> User { get; set; }

        // Views
        DbSet<InventarView> InventarView { get; set; }
        int SaveChanges();
    }
}