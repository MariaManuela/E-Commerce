namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "AgeCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "AgeCategory");
        }
    }
}
