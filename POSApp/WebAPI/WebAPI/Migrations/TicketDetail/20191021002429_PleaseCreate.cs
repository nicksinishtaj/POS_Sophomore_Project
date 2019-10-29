using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.TicketDetail
{
    public partial class PleaseCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ORDERS",
                table: "ORDERS");

            migrationBuilder.RenameTable(
                name: "ORDERS",
                newName: "Tickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "order_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "ORDERS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ORDERS",
                table: "ORDERS",
                column: "order_ID");
        }
    }
}
