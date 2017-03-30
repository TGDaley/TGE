namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNoteField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shows", "Note");
        }
    }
}
