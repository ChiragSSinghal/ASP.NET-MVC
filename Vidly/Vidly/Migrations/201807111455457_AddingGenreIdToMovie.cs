namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGenreIdToMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_ID" });
            RenameColumn(table: "dbo.Movies", name: "Genre_ID", newName: "GenreID");
            AlterColumn("dbo.Movies", "GenreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            AlterColumn("dbo.Movies", "GenreID", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "GenreID", newName: "Genre_ID");
            CreateIndex("dbo.Movies", "Genre_ID");
            AddForeignKey("dbo.Movies", "Genre_ID", "dbo.Genres", "ID");
        }
    }
}
