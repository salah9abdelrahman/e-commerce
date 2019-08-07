namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIsDeletedNotull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductStatus", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Coupons", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.OrderProducts", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Transactions", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Roles", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Transactions", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.OrderProducts", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Orders", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Coupons", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.ProductStatus", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Products", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Categories", "IsDeleted", c => c.Boolean());
        }
    }
}
