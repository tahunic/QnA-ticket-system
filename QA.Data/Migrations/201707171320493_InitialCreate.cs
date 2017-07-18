namespace QA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Fname = c.String(nullable: false, maxLength: 50),
                        Lname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IndexNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(),
                        Content = c.String(nullable: false, maxLength: 200),
                        IsPublic = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                        Year = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Id", "dbo.Users");
            DropForeignKey("dbo.Questions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Professors", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropIndex("dbo.Questions", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Professors", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Questions");
            DropTable("dbo.Students");
            DropTable("dbo.Professors");
            DropTable("dbo.Users");
            DropTable("dbo.Cities");
        }
    }
}
