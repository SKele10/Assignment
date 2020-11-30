namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "CourseTrainer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseTrainer", c => c.String());
        }
    }
}
