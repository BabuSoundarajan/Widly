namespace Widly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Addedmembershiptype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SignUpFee = c.Short(nullable: false),
                    DurationInMonths = c.Byte(nullable: false),
                    DiscountRate = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipType_Id");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipType_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipType_Id" });
            DropColumn("dbo.Customers", "MemberShipType_Id");
            DropColumn("dbo.Customers", "MemberShipTypeId");
            DropTable("dbo.MemberShipTypes");
        }
    }
}
