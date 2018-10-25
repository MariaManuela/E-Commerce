namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Dresses = c.String(),
                        Jackets = c.String(),
                        Bottom = c.String(),
                        Top = c.String(),
                        Footwear = c.String(),
                        Accesories = c.String(),
                        Makeup = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            DropTable("dbo.Categories");
        }
    }
}
