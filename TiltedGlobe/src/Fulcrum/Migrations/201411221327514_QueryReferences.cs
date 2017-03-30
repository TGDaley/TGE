namespace Fulcrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueryReferences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentifierQueryReference",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QueryParameter = c.String(),
                        QueryName = c.String(),
                        CommandPublicationRecord_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommandPublicationRecord", t => t.CommandPublicationRecord_Id)
                .Index(t => t.CommandPublicationRecord_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentifierQueryReference", "CommandPublicationRecord_Id", "dbo.CommandPublicationRecord");
            DropIndex("dbo.IdentifierQueryReference", new[] { "CommandPublicationRecord_Id" });
            DropTable("dbo.IdentifierQueryReference");
        }
    }
}
