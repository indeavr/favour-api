using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class notQuiteSure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Applications",
                newName: "ApplyTime");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId1",
                table: "SavedJobOffers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Periods",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "OngoingJobOffers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobOffers_ConsumerId1",
                table: "SavedJobOffers",
                column: "ConsumerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_ApplicationId",
                table: "Periods",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingJobOffers_PersonConsumerId",
                table: "OngoingJobOffers",
                column: "PersonConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PersonConsumerId",
                table: "Applications",
                column: "PersonConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_PersonConsumers_PersonConsumerId",
                table: "Applications",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_PersonConsumers_PersonConsumerId",
                table: "OngoingJobOffers",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Applications_ApplicationId",
                table: "Periods",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId1",
                table: "SavedJobOffers",
                column: "ConsumerId1",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_PersonConsumers_PersonConsumerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_PersonConsumers_PersonConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Applications_ApplicationId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobOffers_ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Periods_ApplicationId",
                table: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_OngoingJobOffers_PersonConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Applications_PersonConsumerId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "ApplyTime",
                table: "Applications",
                newName: "Time");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers",
                column: "ConsumerId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
