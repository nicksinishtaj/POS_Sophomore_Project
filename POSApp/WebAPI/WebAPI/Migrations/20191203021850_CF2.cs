using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CF2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Servers_server_ID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_server_ID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "server_ID",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "server_ID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_server_ID",
                table: "Tickets",
                column: "server_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Servers_server_ID",
                table: "Tickets",
                column: "server_ID",
                principalTable: "Servers",
                principalColumn: "server_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
