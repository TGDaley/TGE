namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BatchShow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "BatchId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shows", "BatchId");
        }
    }
}
