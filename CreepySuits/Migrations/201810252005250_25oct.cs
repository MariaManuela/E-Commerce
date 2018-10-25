namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25oct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String());
            DropColumn("dbo.Categories", "Dresses");
            DropColumn("dbo.Categories", "Jackets");
            DropColumn("dbo.Categories", "Bottom");
            DropColumn("dbo.Categories", "Top");
            DropColumn("dbo.Categories", "Footwear");
            DropColumn("dbo.Categories", "Accesories");
            DropColumn("dbo.Categories", "Makeup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Makeup", c => c.String());
            AddColumn("dbo.Categories", "Accesories", c => c.String());
            AddColumn("dbo.Categories", "Footwear", c => c.String());
            AddColumn("dbo.Categories", "Top", c => c.String());
            AddColumn("dbo.Categories", "Bottom", c => c.String());
            AddColumn("dbo.Categories", "Jackets", c => c.String());
            AddColumn("dbo.Categories", "Dresses", c => c.String());
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
