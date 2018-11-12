namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "AgeCategoryName", c => c.String());
            AddColumn("dbo.Product", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CategoryName");
            DropColumn("dbo.Product", "AgeCategoryName");
        }
    }
}
