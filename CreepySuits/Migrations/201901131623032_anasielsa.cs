namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anasielsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "PaymentType", c => c.String());
            AddColumn("dbo.Order", "OrderType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "OrderType");
            DropColumn("dbo.Order", "PaymentType");
        }
    }
}
