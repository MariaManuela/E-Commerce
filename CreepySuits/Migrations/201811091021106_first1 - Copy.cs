namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Product", new[] { "Category_CategoryId" });
            DropColumn("dbo.Product", "Category_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Product", "Category_CategoryId");
            AddForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
