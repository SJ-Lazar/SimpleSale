using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleSalesEF.Migrations
{
    public partial class UpdateToDbTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "SalesItems",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<string>(
                name: "VATName",
                table: "ValueAddedTaxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "SalesItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "SalesItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "SalesItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemsPrice",
                table: "SalesItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceVat",
                table: "SalesItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VATName",
                table: "ValueAddedTaxes");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "ItemsPrice",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "PriceVat",
                table: "SalesItems");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "SalesItems",
                newName: "SalePrice");
        }
    }
}
