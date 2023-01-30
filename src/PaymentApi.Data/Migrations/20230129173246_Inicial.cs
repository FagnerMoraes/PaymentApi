using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApi.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COL_TITLE_PRODUCT = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    COL_PRICE_PRODUCT = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_SELLER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SELLER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_TB_SELLER_SellerId",
                        column: x => x.SellerId,
                        principalTable: "TB_SELLER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDERITEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDERITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ORDERITEM_TB_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TB_ORDER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ORDERITEM_TB_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUCT",
                columns: new[] { "Id", "COL_PRICE_PRODUCT", "COL_TITLE_PRODUCT" },
                values: new object[,]
                {
                    { new Guid("9d2b0228-4d0d-4c23-8b49-01a698857708"), 2m, "Produto 02" },
                    { new Guid("9d2b0228-4d0d-4c23-8b49-01a698857709"), 2m, "Produto 01" }
                });

            migrationBuilder.InsertData(
                table: "TB_SELLER",
                columns: new[] { "Id", "CPF", "Email", "Name", "Telefone" },
                values: new object[,]
                {
                    { new Guid("9d2b0228-4d0d-4c23-8b49-01a698857702"), "11111111", "teste@teste.com", "Vendedor01", "123123" },
                    { new Guid("9d2b0228-4d0d-4c23-8b49-01a698857703"), "11111221", "teste@teste.com", "Vendedor02", "123123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_SellerId",
                table: "TB_ORDER",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDERITEM_OrderId",
                table: "TB_ORDERITEM",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDERITEM_ProductId",
                table: "TB_ORDERITEM",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ORDERITEM");

            migrationBuilder.DropTable(
                name: "TB_ORDER");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_SELLER");
        }
    }
}
