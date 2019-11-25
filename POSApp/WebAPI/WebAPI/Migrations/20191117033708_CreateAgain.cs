using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CreateAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Servers_server_ID",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "server_ID",
                table: "Tables",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Servers_server_ID",
                table: "Tables",
                column: "server_ID",
                principalTable: "Servers",
                principalColumn: "server_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Servers_server_ID",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "server_ID",
                table: "Tables",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Servers_server_ID",
                table: "Tables",
                column: "server_ID",
                principalTable: "Servers",
                principalColumn: "server_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
