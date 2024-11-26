using System.Data.Entity.Migrations;

namespace StudentManagement.Migrations
{
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Department");
        }
    }
}
