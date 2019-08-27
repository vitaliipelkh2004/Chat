namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMessesage", "User_ID", "dbo.tblUser");
            DropIndex("dbo.tblMessesage", new[] { "User_ID" });
            DropTable("dbo.tblUser");
            DropTable("dbo.tblMessesage");
        }
    }
}
