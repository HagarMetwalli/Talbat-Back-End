using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class nullableImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemImage",
                table: "Item",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                defaultValueSql: "('Default.png')",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldDefaultValueSql: "('Default.png')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemImage",
                table: "Item",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValueSql: "('Default.png')",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true,
                oldDefaultValueSql: "('Default.png')");
        }
    }
}
