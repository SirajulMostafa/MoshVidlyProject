namespace MoshVidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 225));
            DropColumn("dbo.Customers", "Birthdate");
            CreateIndex("dbo.Customers", "MembershipTypeId");
        }
    }
}
