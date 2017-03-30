namespace Fulcrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventPipeline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventPublicationRecord",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ErrorDetails = c.String(),
                        ErrorHeadline = c.String(),
                        Updated = c.DateTime(),
                        PortableEvent_ClrAssemblyName = c.String(),
                        PortableEvent_ClrTypeName = c.String(),
                        PortableEvent_EventJson = c.String(),
                        PortableEvent_EventJsonSchema = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentifierQueryReference", "EventPublicationRecord_Id", c => c.Guid());
            CreateIndex("dbo.IdentifierQueryReference", "EventPublicationRecord_Id");
            AddForeignKey("dbo.IdentifierQueryReference", "EventPublicationRecord_Id", "dbo.EventPublicationRecord", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentifierQueryReference", "EventPublicationRecord_Id", "dbo.EventPublicationRecord");
            DropIndex("dbo.IdentifierQueryReference", new[] { "EventPublicationRecord_Id" });
            DropColumn("dbo.IdentifierQueryReference", "EventPublicationRecord_Id");
            DropTable("dbo.EventPublicationRecord");
        }
    }
}
