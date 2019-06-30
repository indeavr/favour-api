using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class CompanyProvidrProflePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "CompanyProviders");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoName",
                table: "CompanyProviders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProviders_ProfilePhotoName",
                table: "CompanyProviders",
                column: "ProfilePhotoName");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProviders_Images_ProfilePhotoName",
                table: "CompanyProviders",
                column: "ProfilePhotoName",
                principalTable: "Images",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProviders_Images_ProfilePhotoName",
                table: "CompanyProviders");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProviders_ProfilePhotoName",
                table: "CompanyProviders");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoName",
                table: "CompanyProviders");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "CompanyProviders",
                nullable: true);
        }
    }
}
