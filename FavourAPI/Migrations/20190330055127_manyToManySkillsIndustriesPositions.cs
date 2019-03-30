using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class manyToManySkillsIndustriesPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Industries_IndustryId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Positions_PositionId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PositionId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Positions_IndustryId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Positions");

            migrationBuilder.CreateTable(
                name: "IndustryPositions",
                columns: table => new
                {
                    IndustryId = table.Column<string>(nullable: false),
                    PositionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryPositions", x => new { x.IndustryId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_IndustryPositions_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustryPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionSkills",
                columns: table => new
                {
                    PositionId = table.Column<string>(nullable: false),
                    SkillId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkills", x => new { x.SkillId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PositionSkills_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustryPositions_PositionId",
                table: "IndustryPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_PositionId",
                table: "PositionSkills",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustryPositions");

            migrationBuilder.DropTable(
                name: "PositionSkills");

            migrationBuilder.AddColumn<string>(
                name: "PositionId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndustryId",
                table: "Positions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PositionId",
                table: "Skills",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_IndustryId",
                table: "Positions",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Industries_IndustryId",
                table: "Positions",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Positions_PositionId",
                table: "Skills",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
