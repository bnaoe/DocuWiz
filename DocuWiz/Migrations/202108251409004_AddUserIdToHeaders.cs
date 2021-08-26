namespace DocuWiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToHeaders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headers", "UserId");
        }
    }
}
