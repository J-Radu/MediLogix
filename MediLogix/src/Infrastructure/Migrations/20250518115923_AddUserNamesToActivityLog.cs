using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediLogix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNamesToActivityLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "UserLastName",
                table: "ActivityLogs");
        }
    }
}
