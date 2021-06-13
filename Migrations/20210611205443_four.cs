using Microsoft.EntityFrameworkCore.Migrations;

namespace Talbat.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemReview",
                columns: table => new
                {
                    SystemReviewId = table.Column<int>(type: "int", nullable: false),
                    RateTalabatExperience = table.Column<int>(type: "int", nullable: false),
                    EffortMadeToOrderFood = table.Column<int>(type: "int", nullable: false),
                    RecommendToFriend = table.Column<int>(type: "int", nullable: false),
                    SystemReviewComment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReview", x => x.SystemReviewId);
                    table.ForeignKey(
                        name: "FK_SystemReview_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemReview_ClientId",
                table: "SystemReview",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemReview");
        }
    }
}
