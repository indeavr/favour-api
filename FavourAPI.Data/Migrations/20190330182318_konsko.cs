using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class konsko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Users_UserId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "TimePosted",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "JobOffers",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffers_UserId",
                table: "JobOffers",
                newName: "IX_JobOffers_ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyProviders_ProviderId",
                table: "JobOffers",
                column: "ProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_ProviderId",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "JobOffers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffers_ProviderId",
                table: "JobOffers",
                newName: "IX_JobOffers_UserId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyProviderId",
                table: "JobOffers",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "TimePosted",
                table: "JobOffers",
                columns: new[] { "TimePosted", "Id" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyProviderId",
                table: "JobOffers",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Users_UserId",
                table: "JobOffers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
