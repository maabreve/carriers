namespace FleetTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tracking", "Timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracking", "Timestamp", c => c.DateTime(nullable: false));
        }
    }
}
