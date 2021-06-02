using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class blablablaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferItem_SaleValue",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "OfferItem_TypePercentage",
                table: "OfferItem");

            migrationBuilder.DropColumn(
                name: "Offer_Price",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "OrderItem_SpecialRequest",
                table: "OrderItem",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                defaultValueSql: "('none')",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true,
                oldDefaultValueSql: "('none')");

            migrationBuilder.AlterColumn<string>(
                name: "Offer_Description",
                table: "Offer",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AddColumn<int>(
                name: "OfferItem_SaleValue",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferItem_TypePercentage",
                table: "Offer",
                type: "int",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Job_Title",
                table: "Job",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Job_PostedTime",
                table: "Job",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Job_Description",
                table: "Job",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferItem_SaleValue",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "OfferItem_TypePercentage",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "OrderItem_SpecialRequest",
                table: "OrderItem",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                defaultValueSql: "('none')",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValueSql: "('none')");

            migrationBuilder.AddColumn<int>(
                name: "OfferItem_SaleValue",
                table: "OfferItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferItem_TypePercentage",
                table: "OfferItem",
                type: "int",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Offer_Description",
                table: "Offer",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Offer_Price",
                table: "Offer",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Job_Title",
                table: "Job",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Job_PostedTime",
                table: "Job",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Job_Description",
                table: "Job",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);
        }
    }
}
