namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anasielsa4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "DeliveryType", c => c.String());
            DropColumn("dbo.Order", "OrderType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "OrderType", c => c.String());
            DropColumn("dbo.Order", "DeliveryType");
        }
    }
}
