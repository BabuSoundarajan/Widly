namespace Widly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "MemberShipType_Id" });
            CreateIndex("dbo.Customers", "MembershipType_Id");
        }

        public override void Down()
        {
            DropTable("dbo.customers");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            CreateIndex("dbo.Customers", "MemberShipType_Id");
        }
    }
}
