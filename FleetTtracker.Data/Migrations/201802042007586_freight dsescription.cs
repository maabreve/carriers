namespace FleetTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class freightdsescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Freight", "Description", c => c.String(nullable: false, maxLength: 128, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Freight", "Description");
        }
    }
}
