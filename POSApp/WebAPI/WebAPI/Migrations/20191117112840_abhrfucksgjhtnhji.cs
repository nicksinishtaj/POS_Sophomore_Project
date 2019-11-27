using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class abhrfucksgjhtnhji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "deposit",
                table: "Tickets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "isOpen",
                table: "Tickets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "tip",
                table: "Tickets",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deposit",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "isOpen",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "tip",
                table: "Tickets");
        }
    }
}
