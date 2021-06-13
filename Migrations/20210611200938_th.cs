using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_OrderItem_OrderItemOrderId_OrderItemItemId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_OrderItemOrderId_OrderItemItemId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "OrderItemItemId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "OrderItemOrderId",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemItemId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemOrderId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_OrderItemOrderId_OrderItemItemId",
                table: "Item",
                columns: new[] { "OrderItemOrderId", "OrderItemItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Item_OrderItem_OrderItemOrderId_OrderItemItemId",
                table: "Item",
                columns: new[] { "OrderItemOrderId", "OrderItemItemId" },
                principalTable: "OrderItem",
                principalColumns: new[] { "OrderId", "ItemId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
