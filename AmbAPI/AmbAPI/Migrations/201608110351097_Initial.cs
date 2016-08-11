namespace AmbAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserCode = c.String(nullable: false, maxLength: 128),
                        ID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Mobile = c.String(),
                        SbuID = c.Int(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        PhotoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCode);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        AddTime = c.DateTime(nullable: false),
                        Author = c.String(),
                        Url = c.String(),
                        IsTop = c.Boolean(nullable: false),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportCell",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GroupCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportGroup",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.SBU",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FatherID = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Name = c.String(),
                        Remark = c.String(),
                        AddTime = c.DateTime(nullable: false),
                        Header = c.String(),
                        MemberCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.About",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Tel = c.String(),
                        QQ = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Publisher = c.String(),
                        ViewCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sort = c.String(),
                        BelongID = c.Int(nullable: false),
                        Url = c.String(),
                        ImgInfo = c.String(),
                        AddTime = c.DateTime(nullable: false),
                        AddUser = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccountReport",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KmName = c.String(),
                        FatherID = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        AddUser = c.String(),
                        AddTime = c.DateTime(nullable: false),
                        aa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserCode = c.String(),
                        ScheduleTime = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedule");
            DropTable("dbo.Test");
            DropTable("dbo.AccountReport");
            DropTable("dbo.Photo");
            DropTable("dbo.Notice");
            DropTable("dbo.About");
            DropTable("dbo.SBU");
            DropTable("dbo.ReportGroup");
            DropTable("dbo.ReportCell");
            DropTable("dbo.News");
            DropTable("dbo.User");
        }
    }
}
