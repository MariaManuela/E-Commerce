namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lalala6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderHistory");
            AlterColumn("dbo.OrderHistory", "OrderHistoryId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OrderHistory", "OrderHistoryId");
            DropColumn("dbo.OrderHistory", "RecordId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderHistory", "RecordId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.OrderHistory");
            AlterColumn("dbo.OrderHistory", "OrderHistoryId", c => c.String());
            AddPrimaryKey("dbo.OrderHistory", "RecordId");
        }
    }
}
