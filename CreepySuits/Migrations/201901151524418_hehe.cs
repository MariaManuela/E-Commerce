namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "Type", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Type", c => c.Int(nullable: false));
        }
    }
}
