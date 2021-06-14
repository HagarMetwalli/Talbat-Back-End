using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class blablabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCoupon",
                table: "ClientCoupon");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Promotion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ClientCoupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCoupon",
                table: "ClientCoupon",
                columns: new[] { "ClientId", "CouponId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_StoreId",
                table: "Promotion",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCoupon_OrderId",
                table: "ClientCoupon",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCoupon_Order",
                table: "ClientCoupon",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotion_Store_StoreId",
                table: "Promotion",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCoupon_Order",
                table: "ClientCoupon");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotion_Store_StoreId",
                table: "Promotion");

            migrationBuilder.DropIndex(
                name: "IX_Promotion_StoreId",
                table: "Promotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCoupon",
                table: "ClientCoupon");

            migrationBuilder.DropIndex(
                name: "IX_ClientCoupon_OrderId",
                table: "ClientCoupon");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ClientCoupon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCoupon",
                table: "ClientCoupon",
                columns: new[] { "ClientId", "CouponId" });
        }
    }
}
