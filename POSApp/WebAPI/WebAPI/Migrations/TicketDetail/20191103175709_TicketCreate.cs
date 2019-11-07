using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.TicketDetail
{
    public partial class TicketCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "order_DATETIME",
                table: "Tickets",
                type: "DateTime2",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "order_DATETIME",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2");
        }
    }
}
