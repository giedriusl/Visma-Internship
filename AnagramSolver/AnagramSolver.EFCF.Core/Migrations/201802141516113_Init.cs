namespace AnagramSolver.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CachedAnagrams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordId = c.Int(nullable: false),
                        Anagram = c.String(),
                        CachedWords_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CachedWords", t => t.CachedWords_Id)
                .Index(t => t.CachedWords_Id);
            
            CreateTable(
                "dbo.CachedWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserIp = c.String(),
                        CachedWordId = c.Int(),
                        WordId = c.Int(),
                        SearchTime = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CachedWords", t => t.CachedWordId)
                .ForeignKey("dbo.Words", t => t.WordId)
                .Index(t => t.CachedWordId)
                .Index(t => t.WordId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word1 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLogs", "WordId", "dbo.Words");
            DropForeignKey("dbo.UserLogs", "CachedWordId", "dbo.CachedWords");
            DropForeignKey("dbo.CachedAnagrams", "CachedWords_Id", "dbo.CachedWords");
            DropIndex("dbo.UserLogs", new[] { "WordId" });
            DropIndex("dbo.UserLogs", new[] { "CachedWordId" });
            DropIndex("dbo.CachedAnagrams", new[] { "CachedWords_Id" });
            DropTable("dbo.Words");
            DropTable("dbo.UserLogs");
            DropTable("dbo.CachedWords");
            DropTable("dbo.CachedAnagrams");
        }
    }
}
