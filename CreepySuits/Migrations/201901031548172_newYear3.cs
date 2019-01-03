namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newYear3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "Name", c => c.String());
            AddColumn("dbo.Cart", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Cart", "ProductName");
            DropColumn("dbo.Cart", "ProductPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cart", "ProductPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Cart", "ProductName", c => c.String());
            DropColumn("dbo.Cart", "Price");
            DropColumn("dbo.Cart", "Name");
        }
    }
}
