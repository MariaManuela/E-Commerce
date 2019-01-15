namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class magic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "NrCard", c => c.String(nullable: false, maxLength: 16));
            AddColumn("dbo.Order", "ExpDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "SecurityCode", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Order", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Type");
            DropColumn("dbo.Order", "SecurityCode");
            DropColumn("dbo.Order", "ExpDate");
            DropColumn("dbo.Order", "NrCard");
        }
    }
}
