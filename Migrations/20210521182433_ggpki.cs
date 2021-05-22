using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class ggpki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Store_StoreId1",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_StoreId1",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Offer");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_StoreId",
                table: "Offer",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Store_StoreId",
                table: "Offer",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Store_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Store_StoreId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_StoreId",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "StoreId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "Offer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_StoreId1",
                table: "Offer",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Store_StoreId1",
                table: "Offer",
                column: "StoreId1",
                principalTable: "Store",
                principalColumn: "Store_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
