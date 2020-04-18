﻿namespace MyOdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Dhaba_Id", c => c.Int());
            CreateIndex("dbo.Restaurants", "Dhaba_Id");
            AddForeignKey("dbo.Restaurants", "Dhaba_Id", "dbo.Dhabas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "Dhaba_Id", "dbo.Dhabas");
            DropIndex("dbo.Restaurants", new[] { "Dhaba_Id" });
            DropColumn("dbo.Restaurants", "Dhaba_Id");
        }
    }
}
