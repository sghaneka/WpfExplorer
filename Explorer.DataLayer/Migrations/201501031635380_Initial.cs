namespace Explorer.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.c0_Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Instructor_InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.c0_Instructor", t => t.Instructor_InstructorId)
                .Index(t => t.Instructor_InstructorId);
            
            CreateTable(
                "dbo.c0_Instructor",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(maxLength: 200),
                        RoomNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.c0_Course", "Instructor_InstructorId", "dbo.c0_Instructor");
            DropIndex("dbo.c0_Course", new[] { "Instructor_InstructorId" });
            DropTable("dbo.c0_Instructor");
            DropTable("dbo.c0_Course");
        }
    }
}
