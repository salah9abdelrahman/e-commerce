namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Coupons", "Code", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Coupons", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.OrderProducts", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.OrderProducts", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductStatus", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProductStatus", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.OrderProducts", "Description", c => c.String());
            AlterColumn("dbo.OrderProducts", "Name", c => c.String());
            AlterColumn("dbo.Coupons", "Description", c => c.String());
            AlterColumn("dbo.Coupons", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
    }
}
