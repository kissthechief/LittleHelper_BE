namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventarchangedAndUserChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LHELP.InventarFoods", "Inventar_Id", "LHELP.Inventar");
            DropForeignKey("LHELP.InventarFoods", "Food_Id", "LHELP.Food");
            DropForeignKey("LHELP.UserInventars", "User_Id", "LHELP.User");
            DropForeignKey("LHELP.UserInventars", "Inventar_Id", "LHELP.Inventar");
            DropIndex("LHELP.InventarFoods", new[] { "Inventar_Id" });
            DropIndex("LHELP.InventarFoods", new[] { "Food_Id" });
            DropIndex("LHELP.UserInventars", new[] { "User_Id" });
            DropIndex("LHELP.UserInventars", new[] { "Inventar_Id" });
            AddColumn("LHELP.Inventar", "Food_Id", c => c.Int());
            AddColumn("LHELP.Inventar", "User_Id", c => c.Int());
            CreateIndex("LHELP.Inventar", "Food_Id");
            CreateIndex("LHELP.Inventar", "User_Id");
            AddForeignKey("LHELP.Inventar", "Food_Id", "LHELP.Food", "Id");
            AddForeignKey("LHELP.Inventar", "User_Id", "LHELP.User", "Id");
            DropTable("LHELP.InventarFoods");
            DropTable("LHELP.UserInventars");
        }
        
        public override void Down()
        {
            CreateTable(
                "LHELP.UserInventars",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Inventar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Inventar_Id });
            
            CreateTable(
                "LHELP.InventarFoods",
                c => new
                    {
                        Inventar_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inventar_Id, t.Food_Id });
            
            DropForeignKey("LHELP.Inventar", "User_Id", "LHELP.User");
            DropForeignKey("LHELP.Inventar", "Food_Id", "LHELP.Food");
            DropIndex("LHELP.Inventar", new[] { "User_Id" });
            DropIndex("LHELP.Inventar", new[] { "Food_Id" });
            DropColumn("LHELP.Inventar", "User_Id");
            DropColumn("LHELP.Inventar", "Food_Id");
            CreateIndex("LHELP.UserInventars", "Inventar_Id");
            CreateIndex("LHELP.UserInventars", "User_Id");
            CreateIndex("LHELP.InventarFoods", "Food_Id");
            CreateIndex("LHELP.InventarFoods", "Inventar_Id");
            AddForeignKey("LHELP.UserInventars", "Inventar_Id", "LHELP.Inventar", "Id", cascadeDelete: true);
            AddForeignKey("LHELP.UserInventars", "User_Id", "LHELP.User", "Id", cascadeDelete: true);
            AddForeignKey("LHELP.InventarFoods", "Food_Id", "LHELP.Food", "Id", cascadeDelete: true);
            AddForeignKey("LHELP.InventarFoods", "Inventar_Id", "LHELP.Inventar", "Id", cascadeDelete: true);
        }
    }
}
