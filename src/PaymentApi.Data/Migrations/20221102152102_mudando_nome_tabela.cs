using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApi.Data.Migrations
{
    public partial class mudando_nome_tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Seller_SellerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "TB_VENDEDOR");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "TB_PRODUTO");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "TB_ORDERITEM");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "TB_ORDER");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "TB_ORDERITEM",
                newName: "IX_TB_ORDERITEM_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "TB_ORDERITEM",
                newName: "IX_TB_ORDERITEM_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_SellerId",
                table: "TB_ORDER",
                newName: "IX_TB_ORDER_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_VENDEDOR",
                table: "TB_VENDEDOR",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_PRODUTO",
                table: "TB_PRODUTO",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_ORDERITEM",
                table: "TB_ORDERITEM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_ORDER",
                table: "TB_ORDER",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ORDER_TB_VENDEDOR_SellerId",
                table: "TB_ORDER",
                column: "SellerId",
                principalTable: "TB_VENDEDOR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ORDERITEM_TB_ORDER_OrderId",
                table: "TB_ORDERITEM",
                column: "OrderId",
                principalTable: "TB_ORDER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ORDERITEM_TB_PRODUTO_ProductId",
                table: "TB_ORDERITEM",
                column: "ProductId",
                principalTable: "TB_PRODUTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ORDER_TB_VENDEDOR_SellerId",
                table: "TB_ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_ORDERITEM_TB_ORDER_OrderId",
                table: "TB_ORDERITEM");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_ORDERITEM_TB_PRODUTO_ProductId",
                table: "TB_ORDERITEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_VENDEDOR",
                table: "TB_VENDEDOR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_PRODUTO",
                table: "TB_PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_ORDERITEM",
                table: "TB_ORDERITEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_ORDER",
                table: "TB_ORDER");

            migrationBuilder.RenameTable(
                name: "TB_VENDEDOR",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "TB_PRODUTO",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "TB_ORDERITEM",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "TB_ORDER",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_TB_ORDERITEM_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_ORDERITEM_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_ORDER_SellerId",
                table: "Order",
                newName: "IX_Order_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Seller_SellerId",
                table: "Order",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
