using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class koiznae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Review",
                table: "JobOffers",
                newName: "ResultId");

            migrationBuilder.AlterColumn<string>(
                name: "ResultId",
                table: "JobOffers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Consumers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConsumerId = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ResultId",
                table: "JobOffers",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ConsumerId",
                table: "Results",
                column: "ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Results_ResultId",
                table: "JobOffers",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Results_ResultId",
                table: "JobOffers");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_ResultId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Consumers");

            migrationBuilder.RenameColumn(
                name: "ResultId",
                table: "JobOffers",
                newName: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "Review",
                table: "JobOffers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
