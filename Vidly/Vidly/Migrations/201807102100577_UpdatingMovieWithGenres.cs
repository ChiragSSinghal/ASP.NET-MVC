namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingMovieWithGenres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre_ID", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_ID");
            AddForeignKey("dbo.Movies", "Genre_ID", "dbo.Genres", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_ID" });
            DropColumn("dbo.Movies", "Genre_ID");
        }
    }
}
