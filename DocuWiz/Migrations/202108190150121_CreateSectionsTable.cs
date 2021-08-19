namespace DocuWiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSectionsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Memo = c.String(),
                        HeaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Headers", t => t.HeaderId, cascadeDelete: true)
                .Index(t => t.HeaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "HeaderId", "dbo.Headers");
            DropIndex("dbo.Sections", new[] { "HeaderId" });
            DropTable("dbo.Sections");
        }
    }
}
