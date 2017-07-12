namespace ModelCreator
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HelperModel : DbContext
    {
        public HelperModel()
            : base("name=HelperModel")
        {
        }

        public virtual DbSet<InventarView> InventarView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
