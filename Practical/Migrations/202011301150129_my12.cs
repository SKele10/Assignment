namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.String(nullable: false));
        }
    }
}
