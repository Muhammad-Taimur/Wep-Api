namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dhabas", "Countries");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dhabas", "Countries", c => c.String());
        }
    }
}
