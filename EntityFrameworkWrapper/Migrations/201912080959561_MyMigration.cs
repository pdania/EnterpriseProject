namespace EntityFrameworkWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Startrange = c.Int(name: "Start range", nullable: false),
                        Endrange = c.Int(name: "End range", nullable: false),
                        Count = c.Int(nullable: false),
                        Requesttime = c.DateTime(name: "Request time", nullable: false, precision: 7, storeType: "datetime2"),
                        OwnerGuid = c.Guid(nullable: false),
                        User_Guid = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Guid)
                .Index(t => t.User_Guid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false),
                        Lastentertime = c.DateTime(name: "Last enter time", nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "User_Guid", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Requests", new[] { "User_Guid" });
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
        }
    }
}
