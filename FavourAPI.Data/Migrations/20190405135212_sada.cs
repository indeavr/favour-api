using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class sada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumerJobOffer_Consumers_ConsumerId",
                table: "ConsumerJobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumerJobOffer_JobOffers_JobOfferId",
                table: "ConsumerJobOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumerJobOffer",
                table: "ConsumerJobOffer");

            migrationBuilder.RenameTable(
                name: "ConsumerJobOffer",
                newName: "ConsumerJobOffers");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumerJobOffer_JobOfferId",
                table: "ConsumerJobOffers",
                newName: "IX_ConsumerJobOffers_JobOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumerJobOffers",
                table: "ConsumerJobOffers",
                columns: new[] { "ConsumerId", "JobOfferId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumerJobOffers_Consumers_ConsumerId",
                table: "ConsumerJobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumerJobOffers_JobOffers_JobOfferId",
                table: "ConsumerJobOffers",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumerJobOffers_Consumers_ConsumerId",
                table: "ConsumerJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumerJobOffers_JobOffers_JobOfferId",
                table: "ConsumerJobOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumerJobOffers",
                table: "ConsumerJobOffers");

            migrationBuilder.RenameTable(
                name: "ConsumerJobOffers",
                newName: "ConsumerJobOffer");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumerJobOffers_JobOfferId",
                table: "ConsumerJobOffer",
                newName: "IX_ConsumerJobOffer_JobOfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumerJobOffer",
                table: "ConsumerJobOffer",
                columns: new[] { "ConsumerId", "JobOfferId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumerJobOffer_Consumers_ConsumerId",
                table: "ConsumerJobOffer",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumerJobOffer_JobOffers_JobOfferId",
                table: "ConsumerJobOffer",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
