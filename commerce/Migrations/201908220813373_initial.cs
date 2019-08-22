namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "CouponId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UpdatedTime", c => c.DateTime());
            AlterColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductStatus", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Coupons", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "CouponId", c => c.Int());
            AlterColumn("dbo.Orders", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.OrderProducts", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Transactions", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Roles", "IsDeleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Orders", "CouponId");
            CreateIndex("dbo.AspNetUsers", "RoleId");
            AddForeignKey("dbo.AspNetUsers", "RoleId", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "CouponId");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        RoleId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        UpdatedTime = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropForeignKey("dbo.AspNetUsers", "RoleId", "dbo.Roles");
            DropIndex("dbo.AspNetUsers", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "CouponId" });
            AlterColumn("dbo.Roles", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Transactions", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.OrderProducts", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Orders", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Orders", "CouponId", c => c.Int(nullable: false));
            AlterColumn("dbo.Coupons", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.ProductStatus", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Products", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Categories", "IsDeleted", c => c.Boolean());
            DropColumn("dbo.AspNetUsers", "UpdatedTime");
            DropColumn("dbo.AspNetUsers", "CreationTime");
            DropColumn("dbo.AspNetUsers", "RoleId");
            CreateIndex("dbo.UserRoles", "ApplicationUser_Id");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.Orders", "CouponId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "CouponId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
