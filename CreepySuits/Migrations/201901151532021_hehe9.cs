namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehe9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "NrCard", c => c.String(maxLength: 16));
            AlterColumn("dbo.Order", "SecurityCode", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "SecurityCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Order", "NrCard", c => c.String(nullable: false, maxLength: 16));
        }
    }
}
