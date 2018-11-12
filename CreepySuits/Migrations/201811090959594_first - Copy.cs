namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Product", "Category_CategoryId");
            AddForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Product", new[] { "Category_CategoryId" });
            DropColumn("dbo.Product", "Category_CategoryId");
        }
    }
}
