namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeperateTicketQuantities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "ViewerTicketsIssued", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ViewerRetailPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Shows", "ViewerTicketsSold", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "CommercialTicketsIssued", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "CommercialRetailPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Shows", "CommercialTicketsSold", c => c.Int(nullable: false));
            DropColumn("dbo.Shows", "Tickets");
            DropColumn("dbo.Shows", "TicketsSold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "TicketsSold", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "Tickets", c => c.Int(nullable: false));
            DropColumn("dbo.Shows", "CommercialTicketsSold");
            DropColumn("dbo.Shows", "CommercialRetailPrice");
            DropColumn("dbo.Shows", "CommercialTicketsIssued");
            DropColumn("dbo.Shows", "ViewerTicketsSold");
            DropColumn("dbo.Shows", "ViewerRetailPrice");
            DropColumn("dbo.Shows", "ViewerTicketsIssued");
        }
    }
}
