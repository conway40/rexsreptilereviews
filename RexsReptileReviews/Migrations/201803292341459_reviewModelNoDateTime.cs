namespace RexsReptileReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewModelNoDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
