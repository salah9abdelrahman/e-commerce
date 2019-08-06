namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserRoleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "RoleId");
            AddForeignKey("dbo.AspNetUsers", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
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
            
            DropForeignKey("dbo.AspNetUsers", "RoleId", "dbo.Roles");
            DropIndex("dbo.AspNetUsers", new[] { "RoleId" });
            DropColumn("dbo.AspNetUsers", "RoleId");
            CreateIndex("dbo.UserRoles", "ApplicationUser_Id");
            CreateIndex("dbo.UserRoles", "RoleId");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
