namespace RexsReptileReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Age", c => c.String());
        }
    }
}
