namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xcvbnl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Card", "NrCard", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Card", "SecurityCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Card", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Card", "Type", c => c.String());
            AlterColumn("dbo.Card", "SecurityCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Card", "NrCard", c => c.Int(nullable: false));
        }
    }
}
