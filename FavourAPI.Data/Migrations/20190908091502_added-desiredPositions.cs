using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class addeddesiredPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId1",
                table: "IndustryPositions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ConsumerId",
                table: "Positions",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryPositions_IndustryId1",
                table: "IndustryPositions",
                column: "IndustryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId1",
                table: "IndustryPositions",
                column: "IndustryId1",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Consumers_ConsumerId",
                table: "Positions",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId1",
                table: "IndustryPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Consumers_ConsumerId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_ConsumerId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_IndustryPositions_IndustryId1",
                table: "IndustryPositions");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "IndustryId1",
                table: "IndustryPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
