namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenreTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Action')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Family')");
            Sql("INSERT INTO GenreTypes (Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
