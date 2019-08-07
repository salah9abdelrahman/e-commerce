namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCouponFkNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "CouponId" });
            AlterColumn("dbo.Orders", "CouponId", c => c.Int());
            CreateIndex("dbo.Orders", "CouponId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "CouponId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "CouponId" });
            AlterColumn("dbo.Orders", "CouponId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CouponId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "CouponId", cascadeDelete: true);
        }
    }
}
