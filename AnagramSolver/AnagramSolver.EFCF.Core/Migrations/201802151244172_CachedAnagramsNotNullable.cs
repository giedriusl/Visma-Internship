namespace AnagramSolver.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CachedAnagramsNotNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CachedAnagrams", "WordId", "dbo.CachedWords");
            DropIndex("dbo.CachedAnagrams", new[] { "WordId" });
            AlterColumn("dbo.CachedAnagrams", "WordId", c => c.Int(nullable: false));
            CreateIndex("dbo.CachedAnagrams", "WordId");
            AddForeignKey("dbo.CachedAnagrams", "WordId", "dbo.CachedWords", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CachedAnagrams", "WordId", "dbo.CachedWords");
            DropIndex("dbo.CachedAnagrams", new[] { "WordId" });
            AlterColumn("dbo.CachedAnagrams", "WordId", c => c.Int());
            CreateIndex("dbo.CachedAnagrams", "WordId");
            AddForeignKey("dbo.CachedAnagrams", "WordId", "dbo.CachedWords", "Id");
        }
    }
}
