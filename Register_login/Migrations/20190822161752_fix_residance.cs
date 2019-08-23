using Microsoft.EntityFrameworkCore.Migrations;

namespace Register_login.Migrations
{
    public partial class fix_residance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "direction",
                table: "Residences");

            migrationBuilder.AddColumn<int>(
                name: "direction_id",
                table: "Residences",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "direction_id",
                table: "Residences");

            migrationBuilder.AddColumn<string>(
                name: "direction",
                table: "Residences",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
