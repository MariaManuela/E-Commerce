namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class magic1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "PCity", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "PStreet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "PStreet");
            DropColumn("dbo.Order", "PCity");
        }
    }
}
