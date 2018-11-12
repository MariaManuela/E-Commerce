namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lala98809765876876098787 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Product", "Category_CategoryId");
            AddForeignKey("dbo.Product", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
