using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubeTMS.Core.Migrations
{
    public partial class removingFKstomicroserviceditems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Carriers_CarrierId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Customers_CustomerId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CarrierId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scac = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CarrierId",
                table: "Shipments",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Carriers_CarrierId",
                table: "Shipments",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Customers_CustomerId",
                table: "Shipments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
