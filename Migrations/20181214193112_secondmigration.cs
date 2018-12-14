using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam2.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "activities");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "activities",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "activities",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "activities",
                nullable: true);
        }
    }
}
