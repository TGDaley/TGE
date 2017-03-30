namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Show : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Date = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Tickets = c.Int(nullable: false),
                        TicketsSold = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        UpdatedTimeStamp = c.DateTime(nullable: false),
                        CreatedTimeStamp = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shows");
        }
    }
}
