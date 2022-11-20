using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kindred.Guestbook.DataAccess.Migrations
{
    public partial class AnimalStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status_Status",
                table: "Animals",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Status",
                table: "Animals");
        }
    }
}
