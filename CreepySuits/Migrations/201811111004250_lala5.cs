namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lala5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.OrderDetail", "ProductId");
            CreateIndex("dbo.Cart", "ProductId");
            AddForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Cart", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
    }
}
