using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubeTMS.Core.Migrations
{
    public partial class addcustytoshipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Shipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Customers_CustomerId",
                table: "Shipments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Customers_CustomerId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Shipments");
        }
    }
}
