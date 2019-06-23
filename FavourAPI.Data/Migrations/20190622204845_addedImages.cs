using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class addedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoName",
                table: "Consumers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Name = table.Column<Guid>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_ProfilePhotoName",
                table: "Consumers",
                column: "ProfilePhotoName");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Images_ProfilePhotoName",
                table: "Consumers",
                column: "ProfilePhotoName",
                principalTable: "Images",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Images_ProfilePhotoName",
                table: "Consumers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Consumers_ProfilePhotoName",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoName",
                table: "Consumers");
        }
    }
}
