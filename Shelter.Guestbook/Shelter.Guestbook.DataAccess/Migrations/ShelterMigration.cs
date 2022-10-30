using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelter.Guestbook.DataAccess.Migrations
{
    [Migration(2)]
    public class ShelterMigration : Migration
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
