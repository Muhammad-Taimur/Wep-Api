namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Actor_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Actor_Id");
            AddForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "Actor_Id" });
            DropColumn("dbo.Movies", "Actor_Id");
        }
    }
}
