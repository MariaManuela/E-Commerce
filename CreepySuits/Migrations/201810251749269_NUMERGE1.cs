namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NUMERGE1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Stock", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Stock", c => c.Int(nullable: false));
        }
    }
}
