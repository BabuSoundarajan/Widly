namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingGenreTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Genres", newName: "GenreTypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GenreTypes", newName: "Genres");
        }
    }
}
