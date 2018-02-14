namespace AnagramSolver.EFCF.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Word", c => c.String());
            DropColumn("dbo.Words", "Word1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Words", "Word1", c => c.String());
            DropColumn("dbo.Words", "Word");
        }
    }
}
