namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "Actor_Id" });
            DropColumn("dbo.Movies", "Actor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Actor_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Actor_Id");
            AddForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors", "Id");
        }
    }
}
