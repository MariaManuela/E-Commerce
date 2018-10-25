namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24October : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Specifications = c.String(),
                    Price =c.Double(),
                    Provider = c.String(),
                    DeliveryType = c.String(),
                    Category = c.String(),
                })
                .PrimaryKey(t => t.ProductId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
        }
    }
}
