namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseId", c => c.String());
            AlterColumn("dbo.Trainers", "TrainerId", c => c.String());
            AlterColumn("dbo.Students", "StudentId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Trainers", "TrainerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "CourseId", c => c.Int(nullable: false));
        }
    }
}
