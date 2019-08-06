namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationIdString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Orders", "UserId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserRoles", "UserId", c => c.String());
            CreateIndex("dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.UserRoles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "User_Id");
        }
    }
}
