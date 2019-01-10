namespace Caldest.CSharpConcepts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "Teacher_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Teacher_Id");
            AddForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropColumn("dbo.Courses", "Teacher_Id");
            DropTable("dbo.Teachers");
        }
    }
}
