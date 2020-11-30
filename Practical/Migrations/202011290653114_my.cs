namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerRowId" });
            RenameColumn(table: "dbo.Courses", name: "TrainerRowId", newName: "Trainer_TrainerRowId");
            AlterColumn("dbo.Courses", "Trainer_TrainerRowId", c => c.Int());
            CreateIndex("dbo.Courses", "Trainer_TrainerRowId");
            AddForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers", "TrainerRowId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "Trainer_TrainerRowId" });
            AlterColumn("dbo.Courses", "Trainer_TrainerRowId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "Trainer_TrainerRowId", newName: "TrainerRowId");
            CreateIndex("dbo.Courses", "TrainerRowId");
            AddForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers", "TrainerRowId", cascadeDelete: true);
        }
    }
}
