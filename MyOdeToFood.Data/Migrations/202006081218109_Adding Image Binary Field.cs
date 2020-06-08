namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImageBinaryField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageBinary", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageBinary");
        }
    }
}
