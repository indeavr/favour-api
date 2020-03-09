using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class addedFavours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "SavedJobOffers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "Periods",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "OngoingJobOffers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "JobPhotos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "JobOfferLocations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveFavourId",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: true),
                    Money = table.Column<double>(nullable: false),
                    ResultId = table.Column<Guid>(nullable: true),
                    CompletedStateId = table.Column<Guid>(nullable: true),
                    PersonProviderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favours_CompletedJobOffers_CompletedStateId",
                        column: x => x.CompletedStateId,
                        principalTable: "CompletedJobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favours_PersonProviders_PersonProviderId",
                        column: x => x.PersonProviderId,
                        principalTable: "PersonProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favours_CompanyProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "CompanyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favours_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActiveFavours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveFavours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveFavours_Favours_Id",
                        column: x => x.Id,
                        principalTable: "Favours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_FavourId",
                table: "Skills",
                column: "FavourId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobOffers_FavourId",
                table: "SavedJobOffers",
                column: "FavourId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_FavourId",
                table: "Periods",
                column: "FavourId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingJobOffers_FavourId",
                table: "OngoingJobOffers",
                column: "FavourId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPhotos_FavourId",
                table: "JobPhotos",
                column: "FavourId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocations_FavourId",
                table: "JobOfferLocations",
                column: "FavourId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ActiveFavourId",
                table: "Applications",
                column: "ActiveFavourId");

            migrationBuilder.CreateIndex(
                name: "IX_Favours_CompletedStateId",
                table: "Favours",
                column: "CompletedStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Favours_PersonProviderId",
                table: "Favours",
                column: "PersonProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Favours_ProviderId",
                table: "Favours",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Favours_ResultId",
                table: "Favours",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveFavours_ActiveFavourId",
                table: "Applications",
                column: "ActiveFavourId",
                principalTable: "ActiveFavours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocations_Favours_FavourId",
                table: "JobOfferLocations",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPhotos_Favours_FavourId",
                table: "JobPhotos",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_Favours_FavourId",
                table: "OngoingJobOffers",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Favours_FavourId",
                table: "Periods",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Favours_FavourId",
                table: "SavedJobOffers",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Favours_FavourId",
                table: "Skills",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveFavours_ActiveFavourId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocations_Favours_FavourId",
                table: "JobOfferLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPhotos_Favours_FavourId",
                table: "JobPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Favours_FavourId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Favours_FavourId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Favours_FavourId",
                table: "SavedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Favours_FavourId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "ActiveFavours");

            migrationBuilder.DropTable(
                name: "Favours");

            migrationBuilder.DropIndex(
                name: "IX_Skills_FavourId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobOffers_FavourId",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Periods_FavourId",
                table: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_OngoingJobOffers_FavourId",
                table: "OngoingJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobPhotos_FavourId",
                table: "JobPhotos");

            migrationBuilder.DropIndex(
                name: "IX_JobOfferLocations_FavourId",
                table: "JobOfferLocations");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ActiveFavourId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "SavedJobOffers");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "OngoingJobOffers");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "JobPhotos");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "JobOfferLocations");

            migrationBuilder.DropColumn(
                name: "ActiveFavourId",
                table: "Applications");
        }
    }
}
