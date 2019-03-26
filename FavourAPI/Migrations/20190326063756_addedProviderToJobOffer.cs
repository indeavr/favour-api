using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class addedProviderToJobOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyProviderId",
                table: "JobOffers",
                column: "CompanyProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyProviderId",
                table: "JobOffers",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "JobOffers");
        }
    }
}
