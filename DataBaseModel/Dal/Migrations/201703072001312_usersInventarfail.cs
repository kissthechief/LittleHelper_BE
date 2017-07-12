namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersInventarfail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LHELP.Inventar", "User_Id", "LHELP.User");
            DropForeignKey("LHELP.User", "Inventar_Id", "LHELP.Inventar");
            DropForeignKey("LHELP.User", "Inventar_Id1", "LHELP.Inventar");
            DropIndex("LHELP.Inventar", new[] { "User_Id" });
            DropIndex("LHELP.User", new[] { "Inventar_Id" });
            DropIndex("LHELP.User", new[] { "Inventar_Id1" });
            CreateTable(
                "LHELP.UserInventars",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Inventar_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Inventar_Id })
                .ForeignKey("LHELP.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("LHELP.Inventar", t => t.Inventar_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Inventar_Id);
            
            DropColumn("LHELP.Inventar", "User_Id");
            DropColumn("LHELP.User", "Inventar_Id");
            DropColumn("LHELP.User", "Inventar_Id1");
        }
        
        public override void Down()
        {
            AddColumn("LHELP.User", "Inventar_Id1", c => c.Int());
            AddColumn("LHELP.User", "Inventar_Id", c => c.Int());
            AddColumn("LHELP.Inventar", "User_Id", c => c.Int());
            DropForeignKey("LHELP.UserInventars", "Inventar_Id", "LHELP.Inventar");
            DropForeignKey("LHELP.UserInventars", "User_Id", "LHELP.User");
            DropIndex("LHELP.UserInventars", new[] { "Inventar_Id" });
            DropIndex("LHELP.UserInventars", new[] { "User_Id" });
            DropTable("LHELP.UserInventars");
            CreateIndex("LHELP.User", "Inventar_Id1");
            CreateIndex("LHELP.User", "Inventar_Id");
            CreateIndex("LHELP.Inventar", "User_Id");
            AddForeignKey("LHELP.User", "Inventar_Id1", "LHELP.Inventar", "Id");
            AddForeignKey("LHELP.User", "Inventar_Id", "LHELP.Inventar", "Id");
            AddForeignKey("LHELP.Inventar", "User_Id", "LHELP.User", "Id");
        }
    }
}
