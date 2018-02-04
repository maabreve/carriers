namespace FleetTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tracking", newName: "TrackingCurrentPosition");
            CreateTable(
                "dbo.TrackingLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Lat = c.String(nullable: false, maxLength: 128, unicode: false),
                        Lng = c.String(),
                        FreightId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrackingLog");
            RenameTable(name: "dbo.TrackingCurrentPosition", newName: "Tracking");
        }
    }
}
