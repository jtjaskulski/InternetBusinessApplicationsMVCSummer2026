using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class DicountMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscount",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 1,
                column: "IsDiscount",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 2,
                column: "IsDiscount",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 3,
                column: "IsDiscount",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 4,
                column: "IsDiscount",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 5,
                column: "IsDiscount",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscount",
                table: "Product");
        }
    }
}
