namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LHELP.Food",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoodSort_Id = c.Int(),
                        Messurement_Id = c.Int(),
                        Inventar_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LHELP.FoodSort", t => t.FoodSort_Id)
                .ForeignKey("LHELP.Messurement", t => t.Messurement_Id)
                .ForeignKey("LHELP.Inventar", t => t.Inventar_Id)
                .Index(t => t.FoodSort_Id)
                .Index(t => t.Messurement_Id)
                .Index(t => t.Inventar_Id);
            
            CreateTable(
                "LHELP.FoodSort",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "LHELP.Messurement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "LHELP.Inventar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.String(),
                        Amount = c.Int(nullable: false),
                        Messurement_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LHELP.Messurement", t => t.Messurement_Id)
                .ForeignKey("LHELP.User", t => t.User_Id)
                .Index(t => t.Messurement_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "LHELP.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        EMail = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Street = c.String(),
                        Inventar_Id = c.Int(),
                        Inventar_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LHELP.Inventar", t => t.Inventar_Id)
                .ForeignKey("LHELP.Inventar", t => t.Inventar_Id1)
                .Index(t => t.Inventar_Id)
                .Index(t => t.Inventar_Id1);
            
            CreateTable(
                "LHELP.UserDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        EMail = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("LHELP.User", "Inventar_Id1", "LHELP.Inventar");
            DropForeignKey("LHELP.User", "Inventar_Id", "LHELP.Inventar");
            DropForeignKey("LHELP.Inventar", "User_Id", "LHELP.User");
            DropForeignKey("LHELP.Inventar", "Messurement_Id", "LHELP.Messurement");
            DropForeignKey("LHELP.Food", "Inventar_Id", "LHELP.Inventar");
            DropForeignKey("LHELP.Food", "Messurement_Id", "LHELP.Messurement");
            DropForeignKey("LHELP.Food", "FoodSort_Id", "LHELP.FoodSort");
            DropIndex("LHELP.User", new[] { "Inventar_Id1" });
            DropIndex("LHELP.User", new[] { "Inventar_Id" });
            DropIndex("LHELP.Inventar", new[] { "User_Id" });
            DropIndex("LHELP.Inventar", new[] { "Messurement_Id" });
            DropIndex("LHELP.Food", new[] { "Inventar_Id" });
            DropIndex("LHELP.Food", new[] { "Messurement_Id" });
            DropIndex("LHELP.Food", new[] { "FoodSort_Id" });
            DropTable("LHELP.UserDtoes");
            DropTable("LHELP.User");
            DropTable("LHELP.Inventar");
            DropTable("LHELP.Messurement");
            DropTable("LHELP.FoodSort");
            DropTable("LHELP.Food");
        }
    }
}
