namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itsmybirthday2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "ProductName", c => c.String());
            DropColumn("dbo.OrderDetail", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetail", "ProductName");
        }
    }
}
