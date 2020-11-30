namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class My10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerRowId" });
            RenameColumn(table: "dbo.Courses", name: "TrainerRowId", newName: "Trainer_TrainerRowId");
            AddColumn("dbo.Trainers", "UID", c => c.String());
            AddColumn("dbo.StudentCourses", "Status", c => c.String());
            AddColumn("dbo.Students", "UID", c => c.String());
            AlterColumn("dbo.Courses", "Trainer_TrainerRowId", c => c.Int());
            CreateIndex("dbo.Courses", "Trainer_TrainerRowId");
            AddForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers", "TrainerRowId");
            DropColumn("dbo.Students", "CourseSelected");
            DropColumn("dbo.Students", "CourseStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "CourseStatus", c => c.String());
            AddColumn("dbo.Students", "CourseSelected", c => c.String());
            DropForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "Trainer_TrainerRowId" });
            AlterColumn("dbo.Courses", "Trainer_TrainerRowId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "UID");
            DropColumn("dbo.StudentCourses", "Status");
            DropColumn("dbo.Trainers", "UID");
            RenameColumn(table: "dbo.Courses", name: "Trainer_TrainerRowId", newName: "TrainerRowId");
            CreateIndex("dbo.Courses", "TrainerRowId");
            AddForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers", "TrainerRowId", cascadeDelete: true);
        }
    }
}
