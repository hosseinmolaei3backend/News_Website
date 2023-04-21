namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CommentTitle = c.String(maxLength: 100),
                        Email = c.String(),
                        CommentText = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        TitlePage = c.String(nullable: false, maxLength: 50),
                        ShortDescription = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        SliderShow = c.Boolean(nullable: false),
                        CreatDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.PageGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupId", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "PageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "GroupId" });
            DropIndex("dbo.PageComments", new[] { "PageId" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
            DropTable("dbo.PageComments");
        }
    }
}
