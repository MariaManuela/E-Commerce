namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehe6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "ExpDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "ExpDate", c => c.DateTime(nullable: false));
        }
    }
}
