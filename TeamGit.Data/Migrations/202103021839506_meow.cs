namespace TeamGit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "ReplyId", "dbo.Reply");
            DropIndex("dbo.Comment", new[] { "ReplyId" });
            AlterColumn("dbo.Comment", "ReplyId", c => c.Int());
            CreateIndex("dbo.Comment", "ReplyId");
            AddForeignKey("dbo.Comment", "ReplyId", "dbo.Reply", "ReplyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ReplyId", "dbo.Reply");
            DropIndex("dbo.Comment", new[] { "ReplyId" });
            AlterColumn("dbo.Comment", "ReplyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "ReplyId");
            AddForeignKey("dbo.Comment", "ReplyId", "dbo.Reply", "ReplyId", cascadeDelete: true);
        }
    }
}
