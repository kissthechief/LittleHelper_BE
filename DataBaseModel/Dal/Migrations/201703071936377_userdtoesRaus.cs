namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userdtoesRaus : DbMigration
    {
        public override void Up()
        {
            DropTable("LHELP.UserDtoes");
        }
        
        public override void Down()
        {
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
    }
}
