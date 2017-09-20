namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                        GenreType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreType_Id)
                .Index(t => t.GenreType_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreType_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
