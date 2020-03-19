using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class changes_to_provider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveOfferings_Providers_ProviderId",
                table: "ActiveOfferings");

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

            migrationBuilder.DropIndex(
                name: "IX_ActiveOfferings_ProviderId",
                table: "ActiveOfferings");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "OngoingOfferings");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "CompletedOfferings");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "ActiveOfferings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "OngoingOfferings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "CompletedOfferings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "ActiveOfferings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OngoingOfferings_ProviderId",
                table: "OngoingOfferings",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedOfferings_ProviderId",
                table: "CompletedOfferings",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveOfferings_ProviderId",
                table: "ActiveOfferings",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveOfferings_Providers_ProviderId",
                table: "ActiveOfferings",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
