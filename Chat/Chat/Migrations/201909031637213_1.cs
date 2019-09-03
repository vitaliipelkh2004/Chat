namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblMessesage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblUser", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblUserReceiver",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserR_ID = c.Int(nullable: false),
                        MiniChat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.UserR_ID, t.MiniChat_ID })
                .ForeignKey("dbo.tblMiniChat", t => t.MiniChat_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.UserR_ID, cascadeDelete: true)
                .Index(t => t.UserR_ID)
                .Index(t => t.MiniChat_ID);
            
            CreateTable(
                "dbo.tblMiniChat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblUserVid",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserV_ID = c.Int(nullable: false),
                        MiniChat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.UserV_ID, t.MiniChat_ID })
                .ForeignKey("dbo.tblMiniChat", t => t.MiniChat_ID, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.UserV_ID, cascadeDelete: true)
                .Index(t => t.UserV_ID)
                .Index(t => t.MiniChat_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMessesage", "User_ID", "dbo.tblUser");
            DropForeignKey("dbo.tblUserReceiver", "UserR_ID", "dbo.tblUser");
            DropForeignKey("dbo.tblUserReceiver", "MiniChat_ID", "dbo.tblMiniChat");
            DropForeignKey("dbo.tblUserVid", "UserV_ID", "dbo.tblUser");
            DropForeignKey("dbo.tblUserVid", "MiniChat_ID", "dbo.tblMiniChat");
            DropIndex("dbo.tblUserVid", new[] { "MiniChat_ID" });
            DropIndex("dbo.tblUserVid", new[] { "UserV_ID" });
            DropIndex("dbo.tblUserReceiver", new[] { "MiniChat_ID" });
            DropIndex("dbo.tblUserReceiver", new[] { "UserR_ID" });
            DropIndex("dbo.tblMessesage", new[] { "User_ID" });
            DropTable("dbo.tblUserVid");
            DropTable("dbo.tblMiniChat");
            DropTable("dbo.tblUserReceiver");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblMessesage");
        }
    }
}
