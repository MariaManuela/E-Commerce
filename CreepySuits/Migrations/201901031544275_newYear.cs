namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "ProductName", c => c.String());
            AddColumn("dbo.Cart", "ProductPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cart", "ProductPrice");
            DropColumn("dbo.Cart", "ProductName");
        }
    }
}
