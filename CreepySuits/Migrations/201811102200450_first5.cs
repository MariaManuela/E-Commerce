namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "AgeCategoryName");
            DropColumn("dbo.Product", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "CategoryName", c => c.String());
            AddColumn("dbo.Product", "AgeCategoryName", c => c.String());
        }
    }
}
