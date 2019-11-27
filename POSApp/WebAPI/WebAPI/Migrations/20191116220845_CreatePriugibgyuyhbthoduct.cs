using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CreatePriugibgyuyhbthoduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    server_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    server_LNAME = table.Column<string>(type: "char(30)", nullable: true),
                    server_FNAME = table.Column<string>(type: "char(30)", nullable: true),
                    server_MI = table.Column<string>(type: "char(1)", nullable: true),
                    total_TIPS = table.Column<decimal>(type: "numeric(19,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.server_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    table_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    table_res = table.Column<bool>(type: "bit", nullable: false),
                    CardOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    server_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.table_ID);
                    table.ForeignKey(
                        name: "FK_Tables_Servers_server_ID",
                        column: x => x.server_ID,
                        principalTable: "Servers",
                        principalColumn: "server_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_server_ID",
                table: "Tables",
                column: "server_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
