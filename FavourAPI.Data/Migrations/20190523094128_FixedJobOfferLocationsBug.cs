using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class FixedJobOfferLocationsBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId1",
                table: "JobOfferLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_JobOffers_JobOfferId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_JobOfferId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_JobOfferLocations_JobOfferId1",
                table: "JobOfferLocations");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "JobOfferId1",
                table: "JobOfferLocations");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId",
                table: "JobOfferLocations",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId",
                table: "JobOfferLocations");

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId1",
                table: "JobOfferLocations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_JobOfferId",
                table: "Locations",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocations_JobOfferId1",
                table: "JobOfferLocations",
                column: "JobOfferId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId1",
                table: "JobOfferLocations",
                column: "JobOfferId1",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_JobOffers_JobOfferId",
                table: "Locations",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
