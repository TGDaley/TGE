namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shows", "ApplicationUser_Id");
            AddForeignKey("dbo.Shows", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Shows", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Shows", "ApplicationUser_Id");
        }
    }
}
