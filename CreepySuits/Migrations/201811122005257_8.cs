namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Product", name: "Category_CategoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Product", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Product", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            RenameColumn(table: "dbo.Product", name: "CategoryId", newName: "Category_CategoryId");
        }
    }
}
