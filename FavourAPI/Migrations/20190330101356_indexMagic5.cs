using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class indexMagic5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Skills_JobOffers_JobOfferId", table: "Skills");
            migrationBuilder.DropForeignKey(name: "FK_Periods_JobOffers_JobOfferId", table: "Periods");
            migrationBuilder.DropForeignKey(name: "FK_Applications_JobOffers_JobOfferId", table: "Applications");


            migrationBuilder.DropPrimaryKey(name: "PK_JobOffers", table: "JobOffers");

            migrationBuilder.CreateIndex(
                name: "TimePosted",
                table: "JobOffers",
                columns: new[] { "TimePosted" })
                .Annotation("SqlServer:Clustered", true);
            migrationBuilder.AddPrimaryKey(name: "Id", table: "JobOffers", column: "Id");

            migrationBuilder.AddForeignKey(
                       name: "FK_Periods_JobOffers_JobOfferId",
                       table: "Periods",
                       column: "JobOfferId",
                       principalTable: "JobOffers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                      name: "FK_Skills_JobOffers_JobOfferId",
                      table: "Skills",
                      column: "JobOfferId",
                      principalTable: "JobOffers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                     name: "FK_Applications_JobOffers_JobOfferId",
                     table: "Applications",
                     column: "JobOfferId",
                     principalTable: "JobOffers",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "TimePosted",
                table: "JobOffers");
        }
    }
}
