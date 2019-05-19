using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class manyToManyOfficeIndustry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_Offices_OfficeId",
                table: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_Industries_OfficeId",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Industries");

            migrationBuilder.CreateTable(
                name: "OfficeIndustries",
                columns: table => new
                {
                    OfficeId = table.Column<string>(nullable: false),
                    IndustryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeIndustries", x => new { x.IndustryId, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_OfficeIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeIndustries_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeIndustries_OfficeId",
                table: "OfficeIndustries",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeIndustries");

            migrationBuilder.AddColumn<string>(
                name: "OfficeId",
                table: "Industries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Industries_OfficeId",
                table: "Industries",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_Offices_OfficeId",
                table: "Industries",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
