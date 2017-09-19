namespace Widly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateNameInMembershiptTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay As You Go' Where Id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' Where Id=2");
            Sql("UPDATE MembershipTypes SET Name='Quarterly' Where Id=3");
            Sql("UPDATE MembershipTypes SET Name='Yearly' Where Id=4");
        }

        public override void Down()
        {
        }
    }
}
