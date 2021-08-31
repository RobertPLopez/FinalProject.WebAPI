namespace FinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDavidedits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "AuthorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Review", "AuthorId");
        }
    }
}
