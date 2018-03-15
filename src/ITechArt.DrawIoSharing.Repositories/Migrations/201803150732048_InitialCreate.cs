namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Password = c.String(),
                        UserApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.UserName });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
