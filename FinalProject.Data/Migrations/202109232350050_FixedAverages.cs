namespace FinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAverages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Game", "Genre");
            DropColumn("dbo.Game", "AverageRating");
            DropColumn("dbo.Game", "AgeOfPlayer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "AgeOfPlayer", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.Game", "Genre", c => c.Int(nullable: false));
        }
    }
}
