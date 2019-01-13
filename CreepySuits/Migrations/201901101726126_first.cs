namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistory", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.OrderHistory", "Order_OrderId");
            AddForeignKey("dbo.OrderHistory", "Order_OrderId", "dbo.Order", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderHistory", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.OrderHistory", new[] { "Order_OrderId" });
            DropColumn("dbo.OrderHistory", "Order_OrderId");
        }
    }
}
