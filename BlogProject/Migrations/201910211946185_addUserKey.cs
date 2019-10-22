namespace BlogProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "UserId_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Blogs", "UserId_Id");
            AddForeignKey("dbo.Blogs", "UserId_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Blogs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Blogs", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "UserId_Id" });
            DropColumn("dbo.Blogs", "UserId_Id");
        }
    }
}
