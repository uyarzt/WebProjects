namespace WebAppForTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTab_TestType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestTypes", "Description", c => c.String());
            //DropColumn("dbo.Questions", "TestId");
            DropColumn("dbo.TestTypes", "Tescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestTypes", "Tescription", c => c.String());
            AddColumn("dbo.Questions", "TestId", c => c.Int());
            DropColumn("dbo.TestTypes", "Description");
        }
    }
}
