namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodInventar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LHELP.Food", "Inventar_Id", "LHELP.Inventar");
            DropIndex("LHELP.Food", new[] { "Inventar_Id" });
            CreateTable(
                "LHELP.InventarFoods",
                c => new
                    {
                        Inventar_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inventar_Id, t.Food_Id })
                .ForeignKey("LHELP.Inventar", t => t.Inventar_Id, cascadeDelete: true)
                .ForeignKey("LHELP.Food", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Inventar_Id)
                .Index(t => t.Food_Id);
            
            DropColumn("LHELP.Food", "Inventar_Id");
        }
        
        public override void Down()
        {
            AddColumn("LHELP.Food", "Inventar_Id", c => c.Int());
            DropForeignKey("LHELP.InventarFoods", "Food_Id", "LHELP.Food");
            DropForeignKey("LHELP.InventarFoods", "Inventar_Id", "LHELP.Inventar");
            DropIndex("LHELP.InventarFoods", new[] { "Food_Id" });
            DropIndex("LHELP.InventarFoods", new[] { "Inventar_Id" });
            DropTable("LHELP.InventarFoods");
            CreateIndex("LHELP.Food", "Inventar_Id");
            AddForeignKey("LHELP.Food", "Inventar_Id", "LHELP.Inventar", "Id");
        }
    }
}
