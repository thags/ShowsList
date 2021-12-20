﻿namespace Shows.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateShow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TotalEpisodes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shows");
        }
    }
}
