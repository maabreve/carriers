namespace Carriers.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.IdentityUserLogin", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Rating", "UserId", "dbo.User");
            DropIndex("dbo.Rating", new[] { "UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            AddColumn("dbo.Rating", "UserName", c => c.String(nullable: false, maxLength: 512, unicode: false));
            AlterColumn("dbo.Rating", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.IdentityUserLogin", "User_Id");
            DropTable("dbo.User");
            DropTable("dbo.IdentityUserClaim");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HashT = c.String(nullable: false, maxLength: 512, unicode: false),
                        DateCreated = c.DateTime(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 16, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUserLogin", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rating", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Rating", "UserName");
            CreateIndex("dbo.IdentityUserRole", "UserId");
            CreateIndex("dbo.IdentityUserLogin", "User_Id");
            CreateIndex("dbo.IdentityUserClaim", "UserId");
            CreateIndex("dbo.Rating", "UserId");
            AddForeignKey("dbo.Rating", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.IdentityUserRole", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.IdentityUserLogin", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.User", "Id");
        }
    }
}
