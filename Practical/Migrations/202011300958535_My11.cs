namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class My11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "CourseRowId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "StudentRowId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "CourseRowId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentRowId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.StudentCourses", "StudentRowId");
            CreateIndex("dbo.StudentCourses", "CourseRowId");
            AddForeignKey("dbo.StudentCourses", "StudentRowId", "dbo.Students", "StudentRowId", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "CourseRowId", "dbo.Courses", "CourseRowId", cascadeDelete: true);
        }
    }
}
