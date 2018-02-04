namespace FleetTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trackingdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingCurrentPosition", "Description", c => c.String(nullable: false, maxLength: 128, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackingCurrentPosition", "Description");
        }
    }
}
