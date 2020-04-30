namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ActorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "ActorName");
        }
    }
}
