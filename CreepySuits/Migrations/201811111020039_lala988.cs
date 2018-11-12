namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lala988 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cart", "ProductId");
            CreateIndex("dbo.OrderDetail", "ProductId");
            AddForeignKey("dbo.Cart", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.Cart", new[] { "ProductId" });
        }
    }
}
