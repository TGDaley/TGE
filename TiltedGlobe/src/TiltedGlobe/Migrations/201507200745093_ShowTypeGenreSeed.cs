namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowTypeGenreSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UpdatedTimeStamp = c.DateTime(nullable: false),
                        CreatedTimeStamp = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ShowType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShowTypes", t => t.ShowType_Id)
                .Index(t => t.ShowType_Id);
            
            CreateTable(
                "dbo.ShowTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UpdatedTimeStamp = c.DateTime(nullable: false),
                        CreatedTimeStamp = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shows", "Genre_Id", c => c.Int());
            AddColumn("dbo.Shows", "ShowType_Id", c => c.Int());
            CreateIndex("dbo.Shows", "Genre_Id");
            CreateIndex("dbo.Shows", "ShowType_Id");
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Shows", "ShowType_Id", "dbo.ShowTypes", "Id");
            DropColumn("dbo.Shows", "ShowType");
            DropColumn("dbo.Shows", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ShowType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Shows", "ShowType_Id", "dbo.ShowTypes");
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Genres", "ShowType_Id", "dbo.ShowTypes");
            DropIndex("dbo.Shows", new[] { "ShowType_Id" });
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            DropIndex("dbo.Genres", new[] { "ShowType_Id" });
            DropColumn("dbo.Shows", "ShowType_Id");
            DropColumn("dbo.Shows", "Genre_Id");
            DropTable("dbo.ShowTypes");
            DropTable("dbo.Genres");
        }
    }
}
