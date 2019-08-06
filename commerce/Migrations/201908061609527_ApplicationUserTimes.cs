namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdatedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UpdatedTime");
            DropColumn("dbo.AspNetUsers", "CreationTime");
        }
    }
}
