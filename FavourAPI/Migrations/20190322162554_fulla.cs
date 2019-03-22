using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class fulla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConsumerId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobOfferId",
                table: "Skills",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationStates",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStates", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferStates",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferStates", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SexValue = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CV = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumers_Sexes_SexValue",
                        column: x => x.SexValue,
                        principalTable: "Sexes",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Money = table.Column<decimal>(nullable: false),
                    StateValue = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffers_JobOfferStates_StateValue",
                        column: x => x.StateValue,
                        principalTable: "JobOfferStates",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<string>(nullable: true),
                    StateValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStates_StateValue",
                        column: x => x.StateValue,
                        principalTable: "ApplicationStates",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<DateTime>(nullable: false),
                    EndHour = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periods_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ConsumerId",
                table: "Skills",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobOfferId",
                table: "Skills",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ConsumerId",
                table: "Applications",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobOfferId",
                table: "Applications",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StateValue",
                table: "Applications",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_SexValue",
                table: "Consumers",
                column: "SexValue");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ConsumerId",
                table: "JobOffers",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_StateValue",
                table: "JobOffers",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_UserId",
                table: "JobOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_JobOfferId",
                table: "Periods",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_JobOffers_JobOfferId",
                table: "Skills",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_JobOffers_JobOfferId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "ApplicationStates");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "JobOfferStates");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ConsumerId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_JobOfferId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Skills");
        }
    }
}
