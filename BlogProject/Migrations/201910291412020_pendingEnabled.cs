namespace BlogProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingEnabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Pending", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Pending");
        }
    }
}
