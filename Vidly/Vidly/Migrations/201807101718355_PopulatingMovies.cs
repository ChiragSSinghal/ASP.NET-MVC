namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre) Values ('Hangover', '2009-11-06', '2016-05-04', 5, 'Comedy')");
            Sql("Insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre) Values ('Die Hard', '1988-07-20', '2015-08-23', 10, 'Action')");
            Sql("Insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre) Values ('The Terminator', '1984-10-26', '2015-08-01', 20, 'Action')");
            Sql("Insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre) Values ('Toy Story', '1995-11-22', '2016-09-22', 3, 'Family')");
            Sql("Insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, Genre) Values ('Titanic', '1997-12-19', '2017-12-19', 10, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
