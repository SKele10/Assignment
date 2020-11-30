namespace Practical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "Trainer_TrainerRowId" });
            RenameColumn(table: "dbo.Courses", name: "Trainer_TrainerRowId", newName: "TrainerRowId");
            AlterColumn("dbo.Courses", "TrainerRowId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "TrainerRowId");
            AddForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers", "TrainerRowId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerRowId" });
            AlterColumn("dbo.Courses", "TrainerRowId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "TrainerRowId", newName: "Trainer_TrainerRowId");
            CreateIndex("dbo.Courses", "Trainer_TrainerRowId");
            AddForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers", "TrainerRowId");
        }
    }
}
