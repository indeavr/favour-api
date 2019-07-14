using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class addcompletionstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobOfferStates",
                keyColumn: "Value",
                keyValue: "Failed");

            migrationBuilder.DeleteData(
                table: "JobOfferStates",
                keyColumn: "Value",
                keyValue: "Finished");

            migrationBuilder.AddColumn<string>(
                name: "StateValue",
                table: "Results",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompletionResultStateDb",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletionResultStateDb", x => x.Value);
                });

            migrationBuilder.InsertData(
                table: "JobOfferStates",
                column: "Value",
                value: "Completed");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StateValue",
                table: "Results",
                column: "StateValue");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_CompletionResultStateDb_StateValue",
                table: "Results",
                column: "StateValue",
                principalTable: "CompletionResultStateDb",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_CompletionResultStateDb_StateValue",
                table: "Results");

            migrationBuilder.DropTable(
                name: "CompletionResultStateDb");

            migrationBuilder.DropIndex(
                name: "IX_Results_StateValue",
                table: "Results");

            migrationBuilder.DeleteData(
                table: "JobOfferStates",
                keyColumn: "Value",
                keyValue: "Completed");

            migrationBuilder.DropColumn(
                name: "StateValue",
                table: "Results");

            migrationBuilder.InsertData(
                table: "JobOfferStates",
                column: "Value",
                value: "Failed");

            migrationBuilder.InsertData(
                table: "JobOfferStates",
                column: "Value",
                value: "Finished");
        }
    }
}
