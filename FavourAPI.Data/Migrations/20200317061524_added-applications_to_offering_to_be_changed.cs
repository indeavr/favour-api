using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class addedapplications_to_offering_to_be_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobOffers_ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropColumn(
                name: "ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferingId",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_OfferingId",
                table: "Applications",
                column: "OfferingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Offerings_OfferingId",
                table: "Applications",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers",
                column: "ConsumerId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Offerings_OfferingId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Applications_OfferingId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "OfferingId",
                table: "Applications");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId1",
                table: "SavedJobOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobOffers_ConsumerId1",
                table: "SavedJobOffers",
                column: "ConsumerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId1",
                table: "SavedJobOffers",
                column: "ConsumerId1",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
