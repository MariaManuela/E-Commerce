namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetail", "ProductName");
        }
    }
}
