using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.TicketDetail
{
    public partial class CreateGOD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "prod_ID",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "order_Total",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "order_QTY",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "prod_ID",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "order_Total",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "order_QTY",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
