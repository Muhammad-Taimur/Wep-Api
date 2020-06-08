namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBlobVarBinary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageBlob", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageBlob");
        }
    }
}
