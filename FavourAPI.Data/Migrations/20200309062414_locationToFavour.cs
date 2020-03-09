using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class locationToFavour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocations_Favours_FavourId",
                table: "JobOfferLocations");

            migrationBuilder.DropIndex(
                name: "IX_JobOfferLocations_FavourId",
                table: "JobOfferLocations");

            migrationBuilder.DropColumn(
                name: "FavourId",
                table: "JobOfferLocations");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Locations",
                newName: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Favours",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favours_LocationId",
                table: "Favours",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_Locations_LocationId",
                table: "Favours",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favours_Locations_LocationId",
                table: "Favours");

            migrationBuilder.DropIndex(
                name: "IX_Favours_LocationId",
                table: "Favours");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Favours");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "FavourId",
                table: "JobOfferLocations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocations_FavourId",
                table: "JobOfferLocations",
                column: "FavourId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocations_Favours_FavourId",
                table: "JobOfferLocations",
                column: "FavourId",
                principalTable: "Favours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
