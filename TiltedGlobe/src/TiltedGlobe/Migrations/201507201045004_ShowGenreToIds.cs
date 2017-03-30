namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowGenreToIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "ShowType_Id", "dbo.ShowTypes");
            DropIndex("dbo.Shows", new[] { "ShowType_Id" });
            DropColumn("dbo.Shows", "ShowType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "ShowType_Id", c => c.Int());
            CreateIndex("dbo.Shows", "ShowType_Id");
            AddForeignKey("dbo.Shows", "ShowType_Id", "dbo.ShowTypes", "Id");
        }
    }
}
