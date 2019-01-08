namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oikoj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "GenderAgeCategory_GenderAgeCategoryId", c => c.Int());
            CreateIndex("dbo.Product", "GenderAgeCategory_GenderAgeCategoryId");
            AddForeignKey("dbo.Product", "GenderAgeCategory_GenderAgeCategoryId", "dbo.GenderAgeCategories", "GenderAgeCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "GenderAgeCategory_GenderAgeCategoryId", "dbo.GenderAgeCategories");
            DropIndex("dbo.Product", new[] { "GenderAgeCategory_GenderAgeCategoryId" });
            DropColumn("dbo.Product", "GenderAgeCategory_GenderAgeCategoryId");
        }
    }
}
