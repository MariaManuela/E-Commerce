namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kjkhk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "PaymentType", c => c.Int(nullable: true));
            AlterColumn("dbo.Order", "DeliveryType", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "DeliveryType", c => c.String());
            AlterColumn("dbo.Order", "PaymentType", c => c.String());
        }
    }
}
