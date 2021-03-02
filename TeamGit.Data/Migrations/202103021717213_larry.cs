namespace TeamGit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class larry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Guid(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId);
            
            AddColumn("dbo.Comment", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Comment", "Text", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "ReplyId", c => c.Int(nullable: false));
            AddColumn("dbo.Post", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Post", "Text", c => c.String(nullable: false));
            AddColumn("dbo.Post", "CommentId", c => c.Int());
            CreateIndex("dbo.Comment", "ReplyId");
            CreateIndex("dbo.Post", "CommentId");
            AddForeignKey("dbo.Comment", "ReplyId", "dbo.Reply", "ReplyId", cascadeDelete: true);
            AddForeignKey("dbo.Post", "CommentId", "dbo.Comment", "CommentId");
            DropColumn("dbo.Comment", "OwnerId");
            DropColumn("dbo.Comment", "Title");
            DropColumn("dbo.Comment", "Content");
            DropColumn("dbo.Comment", "CreatedUtc");
            DropColumn("dbo.Comment", "ModifiedUtc");
            DropColumn("dbo.Post", "OwnerId");
            DropColumn("dbo.Post", "Content");
            DropColumn("dbo.Post", "CreatedUtc");
            DropColumn("dbo.Post", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Post", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Post", "Content", c => c.String(nullable: false));
            AddColumn("dbo.Post", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Comment", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Comment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Comment", "Content", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "OwnerId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Post", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "ReplyId", "dbo.Reply");
            DropIndex("dbo.Post", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "ReplyId" });
            DropColumn("dbo.Post", "CommentId");
            DropColumn("dbo.Post", "Text");
            DropColumn("dbo.Post", "AuthorId");
            DropColumn("dbo.Comment", "ReplyId");
            DropColumn("dbo.Comment", "Text");
            DropColumn("dbo.Comment", "AuthorId");
            DropTable("dbo.Reply");
        }
    }
}
