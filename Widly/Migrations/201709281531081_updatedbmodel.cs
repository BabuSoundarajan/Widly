namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbmodel : DbMigration
    {
        public override void Up()
        {
           // DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MemberShipTypes");
           // DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
           // RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypeId");
            //DropPrimaryKey("dbo.MemberShipTypes");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.MemberShipTypes", "Id", c => c.Byte(nullable: false));
           // AddPrimaryKey("dbo.MemberShipTypes", "Id");
           // CreateIndex("dbo.Customers", "MembershipTypeId");
           // AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
        
        //public override void Down()
        //{
        //    DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MemberShipTypes");
        //    DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
        //    DropPrimaryKey("dbo.MemberShipTypes");
        //    AlterColumn("dbo.MemberShipTypes", "Id", c => c.Int(nullable: false, identity: true));
        //    AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
        //    AddPrimaryKey("dbo.MemberShipTypes", "Id");
        //    RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id");
        //    CreateIndex("dbo.Customers", "MembershipType_Id");
        //    AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MemberShipTypes", "Id");
        //}
    }
}
