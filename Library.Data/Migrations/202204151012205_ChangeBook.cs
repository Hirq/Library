namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Person", c => c.String());
            AddColumn("dbo.Books", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Date");
            DropColumn("dbo.Books", "Person");
        }
    }
}
