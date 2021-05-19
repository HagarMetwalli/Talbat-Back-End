using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class CuisineStoreRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuisineId",
                table: "Store",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_CuisineId",
                table: "Store",
                column: "CuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Cuisines_CuisineId",
                table: "Store",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "CuisineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Cuisines_CuisineId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_CuisineId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CuisineId",
                table: "Store");
        }
    }
}
