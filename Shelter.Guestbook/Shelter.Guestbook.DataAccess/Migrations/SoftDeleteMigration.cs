using FluentMigrator;

namespace Shelter.Guestbook.DataAccess.Migrations
{
    [Migration(1)]
    public class SoftDeleteMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Shelters")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Address").AsString().NotNullable()
                .WithColumn("Email").AsString()
                .WithColumn("PhoneNumber").AsString();
        }

        public override void Down()
        {
            Delete.Table("Shelters");
        }
    }
}
