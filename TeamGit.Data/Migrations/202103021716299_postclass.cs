namespace TeamGit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "CommentId", "dbo.Comment");
            DropIndex("dbo.Post", new[] { "CommentId" });
            AlterColumn("dbo.Post", "CommentId", c => c.Int());
            CreateIndex("dbo.Post", "CommentId");
            AddForeignKey("dbo.Post", "CommentId", "dbo.Comment", "CommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "CommentId", "dbo.Comment");
            DropIndex("dbo.Post", new[] { "CommentId" });
            AlterColumn("dbo.Post", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Post", "CommentId");
            AddForeignKey("dbo.Post", "CommentId", "dbo.Comment", "CommentId", cascadeDelete: true);
        }
    }
}
