namespace EntityFrameworkWrapper.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Last enter time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Last enter time");
        }
    }
}
