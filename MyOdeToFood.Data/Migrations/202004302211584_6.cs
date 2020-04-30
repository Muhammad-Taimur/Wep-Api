namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actors", "ActorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "ActorName", c => c.String());
        }
    }
}
