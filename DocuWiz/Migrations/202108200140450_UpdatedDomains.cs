namespace DocuWiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDomains : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sections", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Sections", "Memo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sections", "Memo", c => c.String());
            AlterColumn("dbo.Sections", "Name", c => c.String());
        }
    }
}
