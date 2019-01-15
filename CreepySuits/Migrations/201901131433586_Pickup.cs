namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pickup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickupPoint",
                c => new
                    {
                        PickupPointId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        PickupName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PickupPointId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickupPoint", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PickupPoint", "OrderId", "dbo.Order");
            DropIndex("dbo.PickupPoint", new[] { "OrderId" });
            DropIndex("dbo.PickupPoint", new[] { "ProductId" });
            DropTable("dbo.PickupPoint");
        }
    }
}
