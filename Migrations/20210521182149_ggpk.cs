using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class ggpk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoreId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Store_StoreId1",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_StoreId1",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Offer");
        }
    }
}
