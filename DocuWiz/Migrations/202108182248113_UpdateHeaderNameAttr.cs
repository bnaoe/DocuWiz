namespace DocuWiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHeaderNameAttr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Headers", "Name", c => c.String());
        }
    }
}
