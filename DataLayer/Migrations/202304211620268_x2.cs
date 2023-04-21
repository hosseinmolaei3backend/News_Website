namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageComments", "DateAddComment", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageComments", "DateAddComment");
        }
    }
}
