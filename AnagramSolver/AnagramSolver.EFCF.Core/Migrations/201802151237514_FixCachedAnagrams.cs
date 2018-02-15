namespace AnagramSolver.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCachedAnagrams : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CachedAnagrams", "CachedWords_Id", "dbo.CachedWords");
            DropIndex("dbo.CachedAnagrams", new[] { "CachedWords_Id" });
            DropColumn("dbo.CachedAnagrams", "WordId");
            RenameColumn(table: "dbo.CachedAnagrams", name: "CachedWords_Id", newName: "WordId");
            AlterColumn("dbo.CachedAnagrams", "WordId", c => c.Int(nullable: false));
            CreateIndex("dbo.CachedAnagrams", "WordId");
            AddForeignKey("dbo.CachedAnagrams", "WordId", "dbo.CachedWords", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CachedAnagrams", "WordId", "dbo.CachedWords");
            DropIndex("dbo.CachedAnagrams", new[] { "WordId" });
            AlterColumn("dbo.CachedAnagrams", "WordId", c => c.Int());
            RenameColumn(table: "dbo.CachedAnagrams", name: "WordId", newName: "CachedWords_Id");
            AddColumn("dbo.CachedAnagrams", "WordId", c => c.Int(nullable: false));
            CreateIndex("dbo.CachedAnagrams", "CachedWords_Id");
            AddForeignKey("dbo.CachedAnagrams", "CachedWords_Id", "dbo.CachedWords", "Id");
        }
    }
}
