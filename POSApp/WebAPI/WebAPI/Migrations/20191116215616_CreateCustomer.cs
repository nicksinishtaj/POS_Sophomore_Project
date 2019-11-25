using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class CreateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    cust_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cust_LName = table.Column<string>(type: "char(30)", nullable: true),
                    cust_FName = table.Column<string>(type: "char(30)", nullable: true),
                    cust_MI = table.Column<string>(type: "char(1)", nullable: true),
                    cust_Address = table.Column<string>(type: "varchar(30)", nullable: true),
                    cust_City = table.Column<string>(type: "char(30)", nullable: true),
                    cust_State = table.Column<string>(type: "char(30)", nullable: true),
                    cust_ZIP = table.Column<string>(type: "varchar(10)", nullable: true),
                    cust_Card = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.cust_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
