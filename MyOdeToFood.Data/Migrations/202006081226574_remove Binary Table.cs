namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBinaryTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "ImageBinary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageBinary", c => c.Byte(nullable: false));
        }
    }
}
