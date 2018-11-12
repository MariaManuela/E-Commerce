namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Product", "Category_CategoryId");
            AddForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
