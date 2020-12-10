namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Music : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Genre", c => c.String());
            DropColumn("dbo.Albums", "GenreID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "GenreID", c => c.Int(nullable: false));
            DropColumn("dbo.Albums", "Genre");
        }
    }
}
