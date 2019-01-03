namespace CreepySuits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newYear5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Username", c => c.String());
        }
    }
}
