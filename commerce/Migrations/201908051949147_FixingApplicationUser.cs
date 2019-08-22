namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CreatedBy");
            DropColumn("dbo.AspNetUsers", "UpdatedBy");
            DropColumn("dbo.AspNetUsers", "CreationTime");
            DropColumn("dbo.AspNetUsers", "UpdatedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UpdatedTime", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdatedBy", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.String());
        }
    }
}
