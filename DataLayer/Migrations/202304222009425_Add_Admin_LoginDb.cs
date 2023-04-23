namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Admin_LoginDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 200),
                        Email = c.String(maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminLogins");
        }
    }
}
