namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            AddColumn("dbo.Orders", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRoles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.UserRoles", "ApplicationUser_Id");
            AddForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 40),
                        IsDeleted = c.Boolean(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        UpdatedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.UserRoles", "ApplicationUser_Id");
            DropColumn("dbo.Orders", "User_Id");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
