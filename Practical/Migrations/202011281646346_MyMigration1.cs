namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Student_StudentRowId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentRowId" });
            RenameColumn(table: "dbo.StudentCourses", name: "Student_StudentRowId", newName: "StudentRowId");
            AlterColumn("dbo.StudentCourses", "StudentRowId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentCourses", "StudentRowId");
            AddForeignKey("dbo.StudentCourses", "StudentRowId", "dbo.Students", "StudentRowId", cascadeDelete: true);
            DropColumn("dbo.StudentCourses", "TrainerRowId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCourses", "TrainerRowId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentCourses", "StudentRowId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "StudentRowId" });
            AlterColumn("dbo.StudentCourses", "StudentRowId", c => c.Int());
            RenameColumn(table: "dbo.StudentCourses", name: "StudentRowId", newName: "Student_StudentRowId");
            CreateIndex("dbo.StudentCourses", "Student_StudentRowId");
            AddForeignKey("dbo.StudentCourses", "Student_StudentRowId", "dbo.Students", "StudentRowId");
        }
    }
}
