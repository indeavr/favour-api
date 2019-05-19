using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class noseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Consumers_ConsumerId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_ConsumerId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Consumers",
                newName: "PhoneNumberId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumberId",
                table: "Consumers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ConsumerJobOffer",
                columns: table => new
                {
                    ConsumerId = table.Column<string>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerJobOffer", x => new { x.ConsumerId, x.JobOfferId });
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffer_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffer_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_PhoneNumberId",
                table: "Consumers",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerJobOffer_JobOfferId",
                table: "ConsumerJobOffer",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers");

            migrationBuilder.DropTable(
                name: "ConsumerJobOffer");

            migrationBuilder.DropIndex(
                name: "IX_Consumers_PhoneNumberId",
                table: "Consumers");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberId",
                table: "Consumers",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "ConsumerId",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Consumers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ConsumerId",
                table: "JobOffers",
                column: "ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Consumers_ConsumerId",
                table: "JobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
