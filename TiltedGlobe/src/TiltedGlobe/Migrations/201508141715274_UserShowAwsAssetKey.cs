namespace TiltedGlobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserShowAwsAssetKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "VenueContractAwsAssetKey", c => c.String());
            AddColumn("dbo.Shows", "RoyaltyAgreementAwsAssetKey", c => c.String());
            AddColumn("dbo.Shows", "ShowThumbNailAwsAssetKey", c => c.String());
            AddColumn("dbo.Shows", "PlayBillAwsAssetKey", c => c.String());
            AddColumn("dbo.AspNetUsers", "AwsAssetKey", c => c.String());
            DropColumn("dbo.Shows", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "Image", c => c.String());
            DropColumn("dbo.AspNetUsers", "AwsAssetKey");
            DropColumn("dbo.Shows", "PlayBillAwsAssetKey");
            DropColumn("dbo.Shows", "ShowThumbNailAwsAssetKey");
            DropColumn("dbo.Shows", "RoyaltyAgreementAwsAssetKey");
            DropColumn("dbo.Shows", "VenueContractAwsAssetKey");
        }
    }
}
