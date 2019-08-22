namespace commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeParentCatNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "ParentCatId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ParentCatId", c => c.Int(nullable: false));
        }
    }
}
