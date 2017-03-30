namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketColumnRenaming : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "SingleViewerTicketsIssued", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "SingleViewerBasePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Shows", "SingleViewerTicketsSold", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "CommercialViewerTicketsIssued", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "CommercialViewerBasePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Shows", "CommercialViewerTicketsSold", c => c.Int(nullable: false));
            DropColumn("dbo.Shows", "ViewerTicketsIssued");
            DropColumn("dbo.Shows", "ViewerRetailPrice");
            DropColumn("dbo.Shows", "ViewerTicketsSold");
            DropColumn("dbo.Shows", "CommercialTicketsIssued");
            DropColumn("dbo.Shows", "CommercialRetailPrice");
            DropColumn("dbo.Shows", "CommercialTicketsSold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "CommercialTicketsSold", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "CommercialRetailPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Shows", "CommercialTicketsIssued", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ViewerTicketsSold", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ViewerRetailPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Shows", "ViewerTicketsIssued", c => c.Int(nullable: false));
            DropColumn("dbo.Shows", "CommercialViewerTicketsSold");
            DropColumn("dbo.Shows", "CommercialViewerBasePrice");
            DropColumn("dbo.Shows", "CommercialViewerTicketsIssued");
            DropColumn("dbo.Shows", "SingleViewerTicketsSold");
            DropColumn("dbo.Shows", "SingleViewerBasePrice");
            DropColumn("dbo.Shows", "SingleViewerTicketsIssued");
        }
    }
}
