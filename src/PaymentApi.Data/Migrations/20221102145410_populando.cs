using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApi.Data.Migrations
{
    public partial class populando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 1, 2m, "Produto 01" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 2, 2m, "Produto 02" });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "CPF", "Email", "Name", "Telefone" },
                values: new object[] { 1, "11111111", "teste@teste.com", "Vendedor01", "123123" });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "CPF", "Email", "Name", "Telefone" },
                values: new object[] { 2, "11111221", "teste@teste.com", "Vendedor02", "123123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
