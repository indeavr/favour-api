using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class consumer_string_phoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PersonConsumers_PersonConsumerId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_PersonConsumerId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "PhoneNumbers");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PersonConsumers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PersonConsumers");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "PhoneNumbers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonConsumerId",
                table: "PhoneNumbers",
                column: "PersonConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PersonConsumers_PersonConsumerId",
                table: "PhoneNumbers",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
