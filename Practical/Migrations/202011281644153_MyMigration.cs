namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseRowId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(nullable: false),
                        CourseTrainer = c.String(),
                        CourseArea = c.String(nullable: false),
                        Modules = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        TrainerRowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRowId)
                .ForeignKey("dbo.Trainers", t => t.TrainerRowId, cascadeDelete: true)
                .Index(t => t.TrainerRowId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerRowId = c.Int(nullable: false, identity: true),
                        TrainerId = c.Int(nullable: false),
                        TrainerName = c.String(nullable: false),
                        ExpertiseArea = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerRowId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentCourseRowId = c.Int(nullable: false, identity: true),
                        CourseRowId = c.Int(nullable: false),
                        TrainerRowId = c.Int(nullable: false),
                        Student_StudentRowId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentCourseRowId)
                .ForeignKey("dbo.Courses", t => t.CourseRowId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentRowId)
                .Index(t => t.CourseRowId)
                .Index(t => t.Student_StudentRowId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRowId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        AreaOfInterests = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        Mobile = c.Int(nullable: false),
                        CourseSelected = c.String(),
                        CourseStatus = c.String(),
                    })
                .PrimaryKey(t => t.StudentRowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Student_StudentRowId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseRowId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentRowId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseRowId" });
            DropIndex("dbo.Courses", new[] { "TrainerRowId" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
        }
    }
}
