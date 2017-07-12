namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessurementfrOmInventarDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LHELP.Inventar", "Messurement_Id", "LHELP.Messurement");
            DropIndex("LHELP.Inventar", new[] { "Messurement_Id" });
            DropColumn("LHELP.Inventar", "Messurement_Id");
        }
        
        public override void Down()
        {
            AddColumn("LHELP.Inventar", "Messurement_Id", c => c.Int());
            CreateIndex("LHELP.Inventar", "Messurement_Id");
            AddForeignKey("LHELP.Inventar", "Messurement_Id", "LHELP.Messurement", "Id");
        }
    }
}
