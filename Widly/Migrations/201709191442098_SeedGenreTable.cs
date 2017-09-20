namespace Widly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
        }

        public override void Down()
        {
        }
    }
}
