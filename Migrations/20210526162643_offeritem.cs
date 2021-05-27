using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class offeritem : Migration
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
                oldClrType: typeof(byte[]),
                oldType: "binary(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "OfferItem_SaleValue",
                table: "OfferItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "OfferItem_TypePercentage",
                table: "OfferItem",
                type: "binary(10)",
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
