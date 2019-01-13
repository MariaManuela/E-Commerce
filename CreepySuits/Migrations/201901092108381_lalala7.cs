namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lalala7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHistory", "RecordId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderHistory", "RecordId");
        }
    }
}
