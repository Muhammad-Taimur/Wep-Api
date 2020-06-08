namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImaagePath : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "Path", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "Path", c => c.Binary());
        }
    }
}
