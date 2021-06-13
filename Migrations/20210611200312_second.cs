using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubItemCategoryDescription",
                table: "SubItemCategory");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerPhoneNumber",
                table: "TempPartnerRegisterationDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PartnerPhoneNumber",
                table: "TempPartnerRegisterationDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SubItemCategoryDescription",
                table: "SubItemCategory",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
