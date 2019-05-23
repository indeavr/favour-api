using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class removedIndustryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeIndustries_Industries_IndustryId",
                table: "OfficeIndustries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Industries",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Industries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Industries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Industries",
                table: "Industries",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeIndustries_Industries_IndustryId",
                table: "OfficeIndustries",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeIndustries_Industries_IndustryId",
                table: "OfficeIndustries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Industries",
                table: "Industries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Industries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Industries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Industries",
                table: "Industries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeIndustries_Industries_IndustryId",
                table: "OfficeIndustries",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
