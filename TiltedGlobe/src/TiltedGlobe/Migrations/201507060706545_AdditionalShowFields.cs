namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalShowFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "ShowDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shows", "Name", c => c.String());
            AddColumn("dbo.Shows", "ShowType", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "EstimatedDuration", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ShouldConvertToOnDemand", c => c.Boolean(nullable: false));
            AddColumn("dbo.Shows", "IsOwner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Shows", "IsDelayedViewingEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Shows", "AllowCommercialViewersToStream", c => c.Boolean(nullable: false));
            DropColumn("dbo.Shows", "Date");
            DropColumn("dbo.Shows", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "Title", c => c.String());
            AddColumn("dbo.Shows", "Date", c => c.String());
            DropColumn("dbo.Shows", "AllowCommercialViewersToStream");
            DropColumn("dbo.Shows", "IsDelayedViewingEnabled");
            DropColumn("dbo.Shows", "IsOwner");
            DropColumn("dbo.Shows", "ShouldConvertToOnDemand");
            DropColumn("dbo.Shows", "EstimatedDuration");
            DropColumn("dbo.Shows", "Rating");
            DropColumn("dbo.Shows", "Genre");
            DropColumn("dbo.Shows", "ShowType");
            DropColumn("dbo.Shows", "Name");
            DropColumn("dbo.Shows", "ShowDate");
        }
    }
}
