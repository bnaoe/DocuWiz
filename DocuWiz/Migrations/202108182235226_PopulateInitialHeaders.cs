namespace DocuWiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateInitialHeaders : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert headers on");
            Sql("insert into headers (Id, Name) values (1,'World Bank')");
            Sql("insert into headers (Id, Name) values (2,'Self-Care')");
            Sql("insert into headers (Id, Name) values (3,'Therapeutic Activities')");
            Sql("insert into headers (Id, Name) values (4,'Neuromuscular Re-Education')");
            Sql("insert into headers (Id, Name) values (5,'Therapeutic Exercise')");
            Sql("insert into headers (Id, Name) values (6,'Cognition')");
            Sql("set identity_insert headers off");
        }
        
        public override void Down()
        {
        }
    }
}
