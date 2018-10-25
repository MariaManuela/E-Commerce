namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25oct2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GenderAgeCategories", "Name", c => c.String());
            DropColumn("dbo.GenderAgeCategories", "Male");
            DropColumn("dbo.GenderAgeCategories", "Female");
            DropColumn("dbo.GenderAgeCategories", "Kids");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GenderAgeCategories", "Kids", c => c.String());
            AddColumn("dbo.GenderAgeCategories", "Female", c => c.String());
            AddColumn("dbo.GenderAgeCategories", "Male", c => c.String());
            DropColumn("dbo.GenderAgeCategories", "Name");
        }
    }
}
