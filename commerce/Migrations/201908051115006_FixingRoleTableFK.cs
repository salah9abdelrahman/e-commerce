namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRoleTableFK : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Roles", "UserRoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "UserRoleId", c => c.Int(nullable: false));
        }
    }
}
