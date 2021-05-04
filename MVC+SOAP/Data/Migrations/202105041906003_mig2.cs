namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "FacultyNumber", c => c.String());
            AddColumn("dbo.Students", "YearsInUniversity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "YearsInUniversity");
            DropColumn("dbo.Students", "FacultyNumber");
            DropColumn("dbo.Students", "Age");
        }
    }
}
