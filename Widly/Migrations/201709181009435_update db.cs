namespace Widly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            CreateIndex("dbo.Customers", "MembershipTypeId");
        }

        public override void Down()
        {
            //DropTable("dbo.customers");
            //DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            //CreateIndex("dbo.Customers", "MemberShipTypeId");
        }
    }
}
