using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CreateAgainAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    order_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    order_DATETIME = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    order_QTY = table.Column<int>(nullable: false),
                    order_Total = table.Column<int>(nullable: false),
                    prod_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.order_ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Products_prod_ID",
                        column: x => x.prod_ID,
                        principalTable: "Products",
                        principalColumn: "prod_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_prod_ID",
                table: "Tickets",
                column: "prod_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
