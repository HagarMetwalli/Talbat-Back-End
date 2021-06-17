using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class ee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReview_RateStatus",
                table: "ItemReview");

            migrationBuilder.DropIndex(
                name: "IX_ItemReview_RateStatus_Id",
                table: "ItemReview");

            migrationBuilder.RenameColumn(
                name: "RateStatusId",
                table: "ItemReview",
                newName: "Rate");

            migrationBuilder.AlterColumn<int>(
                name: "StorePreOrder",
                table: "Store",
                type: "int",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "ItemReview",
                newName: "RateStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "StorePreOrder",
                table: "Store",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false);

            migrationBuilder.CreateIndex(
                name: "IX_ItemReview_RateStatus_Id",
                table: "ItemReview",
                column: "RateStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReview_RateStatus",
                table: "ItemReview",
                column: "RateStatusId",
                principalTable: "RateStatus",
                principalColumn: "RateStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
