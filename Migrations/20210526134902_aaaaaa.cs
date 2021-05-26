using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class aaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OfferItem_TypePercentage",
                table: "OfferItem",
                type: "int",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "OfferItem_SaleValue",
                table: "OfferItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "OfferItem_TypePercentage",
                table: "OfferItem",
                type: "bit",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<double>(
                name: "OfferItem_SaleValue",
                table: "OfferItem",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
