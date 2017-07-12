namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nickname : DbMigration
    {
        public override void Up()
        {
            AddColumn("LHELP.User", "Nickname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("LHELP.User", "Nickname");
        }
    }
}
