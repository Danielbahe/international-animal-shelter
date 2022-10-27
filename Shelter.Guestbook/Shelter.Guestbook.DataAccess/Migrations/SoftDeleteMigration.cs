using FluentMigrator;

namespace Shelter.Guestbook.DataAccess.Migrations
{
    [Migration(1)]
    public class SoftDeleteMigration : Migration
    {
        public override void Up()
        {
            Alter.Table("Animals")
                .AddColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table("Animals");
        }
    }
}
