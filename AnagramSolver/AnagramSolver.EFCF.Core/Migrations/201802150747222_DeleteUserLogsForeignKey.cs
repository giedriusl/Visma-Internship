namespace AnagramSolver.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserLogsForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserLogs", "WordId", "dbo.Words");
            DropIndex("dbo.UserLogs", new[] { "WordId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.UserLogs", "WordId");
            AddForeignKey("dbo.UserLogs", "WordId", "dbo.Words", "Id");
        }
    }
}
