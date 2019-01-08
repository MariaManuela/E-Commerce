namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imb3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetail", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "ProductName", c => c.String());
        }
    }
}
