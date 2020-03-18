using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedJobOffers_Providers_ProviderId",
                table: "CompletedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Providers_ProviderId",
                table: "OngoingJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_CompletedJobOffers_ProviderId",
                table: "CompletedJobOffers");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "CompletedJobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "OngoingOfferings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "CompletedOfferings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OngoingOfferings_ProviderId",
                table: "OngoingOfferings",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedOfferings_ProviderId",
                table: "CompletedOfferings",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedOfferings_Providers_ProviderId",
                table: "CompletedOfferings",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingOfferings_Providers_ProviderId",
                table: "OngoingOfferings",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedOfferings_Providers_ProviderId",
                table: "CompletedOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingOfferings_Providers_ProviderId",
                table: "OngoingOfferings");

            migrationBuilder.DropIndex(
                name: "IX_OngoingOfferings_ProviderId",
                table: "OngoingOfferings");

            migrationBuilder.DropIndex(
                name: "IX_CompletedOfferings_ProviderId",
                table: "CompletedOfferings");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "OngoingOfferings");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "CompletedOfferings");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "CompletedJobOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedJobOffers_ProviderId",
                table: "CompletedJobOffers",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedJobOffers_Providers_ProviderId",
                table: "CompletedJobOffers",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_Providers_ProviderId",
                table: "OngoingJobOffers",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
