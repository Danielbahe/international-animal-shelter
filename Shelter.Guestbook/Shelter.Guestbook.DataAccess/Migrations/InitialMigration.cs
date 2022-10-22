using FluentMigrator;

namespace Shelter.Guestbook.DataAccess.Migrations
{
    [Migration(0)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Animals")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Species").AsString().NotNullable()
                .WithColumn("Description").AsString();
        }

        public override void Down()
        {
            Delete.Table("Animals");
        }
    }
}
