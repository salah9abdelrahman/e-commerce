namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppicationUserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.String());
            AddColumn("dbo.AspNetUsers", "UpdatedBy", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdatedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UpdatedTime");
            DropColumn("dbo.AspNetUsers", "CreationTime");
            DropColumn("dbo.AspNetUsers", "UpdatedBy");
            DropColumn("dbo.AspNetUsers", "CreatedBy");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
        }
    }
}
