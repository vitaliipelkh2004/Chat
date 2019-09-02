namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblMiniChat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        User_ID_1 = c.Int(nullable: false),
                        User_ID_2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblUser", t => t.User_ID_1, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.User_ID_2, cascadeDelete: true)
                .Index(t => t.User_ID_1)
                .Index(t => t.User_ID_2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMiniChat", "User_ID_2", "dbo.tblUser");
            DropForeignKey("dbo.tblMiniChat", "User_ID_1", "dbo.tblUser");
            DropIndex("dbo.tblMiniChat", new[] { "User_ID_2" });
            DropIndex("dbo.tblMiniChat", new[] { "User_ID_1" });
            DropTable("dbo.tblMiniChat");
        }
    }
}
