namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenderAgeCategories",
                c => new
                    {
                        GenderAgeCategoryId = c.Int(nullable: false, identity: true),
                        Male = c.String(),
                        Female = c.String(),
                        Kids = c.String(),
                    })
                .PrimaryKey(t => t.GenderAgeCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GenderAgeCategories");
        }
    }
}
