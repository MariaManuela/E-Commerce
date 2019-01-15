namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Card : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        NrCard = c.Int(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Card", "OrderId", "dbo.Order");
            DropIndex("dbo.Card", new[] { "OrderId" });
            DropIndex("dbo.Card", new[] { "ProductId" });
            DropTable("dbo.Card");
        }
    }
}
