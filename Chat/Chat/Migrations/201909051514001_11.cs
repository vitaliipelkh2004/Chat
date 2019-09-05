namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblUser", "IsRead");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUser", "IsRead", c => c.Boolean(nullable: false));
        }
    }
}
