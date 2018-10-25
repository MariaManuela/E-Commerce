namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NUMERGE2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Specifications", c => c.String());
            DropColumn("dbo.Product", "Specification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Specification", c => c.String());
            DropColumn("dbo.Product", "Specifications");
        }
    }
}
