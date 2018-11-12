namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lala9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Product", new[] { "Category_CategoryId" });
        
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Specifications = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.String(),
                        Provider = c.String(),
                        DeliveryType = c.String(),
                        AgeCategoryName = c.String(),
                        PicUrl = c.String(),
                        CategoryName = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateIndex("dbo.Product", "Category_CategoryId");
            AddForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
