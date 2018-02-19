namespace AnagramSolver.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLogChangeWordIdToWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLogs", "Word", c => c.String());
            DropColumn("dbo.UserLogs", "WordId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLogs", "WordId", c => c.Int());
            DropColumn("dbo.UserLogs", "Word");
        }
    }
}
