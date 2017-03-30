namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceType : DbMigration
    {
        public override void Up()
        {
					// drop some default values. these are automatically created and don't need to be in the Down()

					Sql("ALTER TABLE dbo.Shows DROP CONSTRAINT DF__Shows__SingleVie__3B40CD36");
					Sql("ALTER TABLE dbo.Shows DROP CONSTRAINT DF__Shows__Commercia__3E1D39E1");

            AlterColumn("dbo.Shows", "SingleViewerBasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Shows", "CommercialViewerBasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shows", "CommercialViewerBasePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Shows", "SingleViewerBasePrice", c => c.Double(nullable: false));
        }
    }
}
