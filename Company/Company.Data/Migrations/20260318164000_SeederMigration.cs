using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeederMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "IdCategory", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Find the latest electronic gadgets.", "Electronics" },
                    { 2, "Discover a world of knowledge.", "Books" },
                    { 3, "Shop for the latest fashion trends.", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "IdNews", "Content", "DisplayOrder", "LinkTitle", "Title" },
                values: new object[,]
                {
                    { 1, "We are excited to launch our latest product.", 1, "New Product", "Announcing Our New Product" },
                    { 2, "We have partnered with XYZ Corp to expand our reach.", 2, "Partnership", "New Partnership with XYZ Corp" },
                    { 3, "We are proud to be recognized for our achievements.", 3, "Award", "We Won an Industry Award" }
                });

            migrationBuilder.InsertData(
                table: "Page",
                columns: new[] { "IdPage", "Content", "DisplayOrder", "LinkTitle", "Title" },
                values: new object[,]
                {
                    { 1, "We are a leading provider of innovative solutions.", 1, "About Us", "About Our Company" },
                    { 2, "We offer a wide range of services to meet your needs.", 2, "Services", "Our Services" },
                    { 3, "Get in touch with us for more information.", 3, "Contact", "Contact Us" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "IdProduct", "Code", "Description", "FotoURL", "IdCategory", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "ELEC-001", "A powerful and feature-rich smartphone.", "https://via.placeholder.com/150", 1, "Smartphone", 699.99m },
                    { 2, "BOOK-001", "A classic novel by F. Scott Fitzgerald.", "https://via.placeholder.com/150", 2, "The Great Gatsby", 12.99m },
                    { 3, "CLTH-001", "A comfortable and stylish t-shirt.", "https://via.placeholder.com/150", 3, "T-Shirt", 19.99m },
                    { 4, "ELEC-002", "A high-performance laptop for work and play.", "https://via.placeholder.com/150", 1, "Laptop", 1299.99m },
                    { 5, "BOOK-002", "A timeless story of justice and prejudice.", "https://via.placeholder.com/150", 2, "To Kill a Mockingbird", 14.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "IdNews",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "IdNews",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "IdNews",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Page",
                keyColumn: "IdPage",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Page",
                keyColumn: "IdPage",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Page",
                keyColumn: "IdPage",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "IdProduct",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "IdCategory",
                keyValue: 3);
        }
    }
}