using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autocomplete.Demo.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceUserContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "device_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Forename = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    KeypadId = table.Column<string>(type: "TEXT", nullable: false),
                    CardId = table.Column<string>(type: "TEXT", nullable: false),
                    EnrolmentId = table.Column<string>(type: "TEXT", nullable: false),
                    Pin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_users");
        }
    }
}
