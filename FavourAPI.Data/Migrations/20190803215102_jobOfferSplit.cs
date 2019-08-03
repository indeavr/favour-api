using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class jobOfferSplit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_JobOfferStates_StateValue",
                table: "JobOffers");

            migrationBuilder.DropTable(
                name: "ConsumerJobOffers");

            migrationBuilder.DropTable(
                name: "JobOfferStates");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_StateValue",
                table: "JobOffers");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("04689ec3-e820-4f8b-8cd1-db03d779f981"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("26895ddc-18f5-4b8e-911f-546ef0df530c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("54f63b6e-3db7-4894-9240-eb9638031bdf"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7e68df07-31e4-4e85-8b99-69125731aff3"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a165c1be-4c0b-4cdb-800f-e85f1bc19051"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("bbb3ec51-80d0-4cee-8ab6-758fdcdac141"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d31ac721-65f1-42ce-b64b-41ba6c244a33"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d9260bce-0d36-4561-b4fc-28b9a7fd35c4"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("f6d161e9-38d5-43fb-a933-395bf635eab5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("03b195de-45a3-44bd-970b-7beead999695"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("52682b24-4214-4f94-9bdd-b7bcd49b8ce7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("73ea8042-726b-4d05-bb2f-e95d6fefdcbb"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("abcdf883-6f79-443a-a5cb-34e2e3a2d614"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("dac7c287-5740-4480-9c24-e619451c2a42"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("db403555-56b7-488e-adc5-7df25c4a0344"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("dba22efb-5054-4ba0-b3b0-fbe82a6eefa2"));

            migrationBuilder.DropColumn(
                name: "StateValue",
                table: "JobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveJobOfferId",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActiveJobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveJobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveJobOffers_JobOffers_Id",
                        column: x => x.Id,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedJobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultId = table.Column<Guid>(nullable: true),
                    ConsumerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedJobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedJobOffers_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompletedJobOffers_JobOffers_Id",
                        column: x => x.Id,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedJobOffers_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OngoingJobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngoingJobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OngoingJobOffers_JobOffers_Id",
                        column: x => x.Id,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedJobOffers",
                columns: table => new
                {
                    ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedJobOffers", x => new { x.ConsumerId, x.JobOfferId });
                    table.ForeignKey(
                        name: "FK_SavedJobOffers_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedJobOffers_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("da709213-0650-4806-9f53-1eab31bc8e95"), null, "Test industry 1" },
                    { new Guid("217aeb85-dbb0-447a-b603-e83c9e7c4fd8"), null, "Test industry 2" },
                    { new Guid("61c0b069-dbbb-4904-89a0-abcbc77d0c2d"), null, "Test industry 3" },
                    { new Guid("32f88f25-9cfa-43ea-bf82-c3dc556cb35a"), null, "Test industry 4" },
                    { new Guid("32d9844c-2a20-4301-acd2-d9267c1d56b9"), null, "Test industry 5" },
                    { new Guid("c8c362a8-053d-4a7e-bd29-eaf641f041f8"), null, "Test industry 6" },
                    { new Guid("543a04e7-0d27-48c7-9ffe-7b118f1e2367"), null, "Test industry 7" },
                    { new Guid("7eabe811-117e-4e5a-954b-47bab514b9e9"), null, "Test industry 8" },
                    { new Guid("353a8925-ae2a-41e2-8352-e1c8297badc8"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("48adbd4a-5f8b-4592-9c3d-9632988ab656"), null, null, "Test position 1" },
                    { new Guid("352b8c3b-22d0-42de-bba9-33a3add5331d"), null, null, "Test position 2" },
                    { new Guid("f9aba110-896f-4026-84cc-f8a8c71009b3"), null, null, "Test position 3" },
                    { new Guid("aa7256ec-2494-45c6-aa85-4c773ec4db33"), null, null, "Test position 4" },
                    { new Guid("8dfcd12d-9a97-4cfc-b492-5920e1571f74"), null, null, "Test position 5" },
                    { new Guid("aee6824e-147e-4787-8105-25728ae2fc0a"), null, null, "Test position 6" },
                    { new Guid("b1b8f2dd-3949-454f-971f-2cd0c4739c91"), null, null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ActiveJobOfferId",
                table: "Applications",
                column: "ActiveJobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedJobOffers_ConsumerId",
                table: "CompletedJobOffers",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedJobOffers_ResultId",
                table: "CompletedJobOffers",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingJobOffers_ConsumerId",
                table: "OngoingJobOffers",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobOffers_JobOfferId",
                table: "SavedJobOffers",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveJobOffers_ActiveJobOfferId",
                table: "Applications",
                column: "ActiveJobOfferId",
                principalTable: "ActiveJobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveJobOffers_ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "ActiveJobOffers");

            migrationBuilder.DropTable(
                name: "CompletedJobOffers");

            migrationBuilder.DropTable(
                name: "OngoingJobOffers");

            migrationBuilder.DropTable(
                name: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("217aeb85-dbb0-447a-b603-e83c9e7c4fd8"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("32d9844c-2a20-4301-acd2-d9267c1d56b9"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("32f88f25-9cfa-43ea-bf82-c3dc556cb35a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("353a8925-ae2a-41e2-8352-e1c8297badc8"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("543a04e7-0d27-48c7-9ffe-7b118f1e2367"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("61c0b069-dbbb-4904-89a0-abcbc77d0c2d"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7eabe811-117e-4e5a-954b-47bab514b9e9"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("c8c362a8-053d-4a7e-bd29-eaf641f041f8"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("da709213-0650-4806-9f53-1eab31bc8e95"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("352b8c3b-22d0-42de-bba9-33a3add5331d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("48adbd4a-5f8b-4592-9c3d-9632988ab656"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("8dfcd12d-9a97-4cfc-b492-5920e1571f74"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("aa7256ec-2494-45c6-aa85-4c773ec4db33"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("aee6824e-147e-4787-8105-25728ae2fc0a"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b1b8f2dd-3949-454f-971f-2cd0c4739c91"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f9aba110-896f-4026-84cc-f8a8c71009b3"));

            migrationBuilder.DropColumn(
                name: "ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "StateValue",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsumerJobOffers",
                columns: table => new
                {
                    ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerJobOffers", x => new { x.ConsumerId, x.JobOfferId });
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffers_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffers_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("26895ddc-18f5-4b8e-911f-546ef0df530c"), null, "Test industry 6" },
                    { new Guid("d9260bce-0d36-4561-b4fc-28b9a7fd35c4"), null, "Test industry 9" },
                    { new Guid("f6d161e9-38d5-43fb-a933-395bf635eab5"), null, "Test industry 8" },
                    { new Guid("bbb3ec51-80d0-4cee-8ab6-758fdcdac141"), null, "Test industry 7" },
                    { new Guid("d31ac721-65f1-42ce-b64b-41ba6c244a33"), null, "Test industry 1" },
                    { new Guid("04689ec3-e820-4f8b-8cd1-db03d779f981"), null, "Test industry 2" },
                    { new Guid("a165c1be-4c0b-4cdb-800f-e85f1bc19051"), null, "Test industry 3" },
                    { new Guid("54f63b6e-3db7-4894-9240-eb9638031bdf"), null, "Test industry 4" },
                    { new Guid("7e68df07-31e4-4e85-8b99-69125731aff3"), null, "Test industry 5" }
                });

            migrationBuilder.InsertData(
                table: "JobOfferStates",
                column: "Value",
                values: new object[]
                {
                    "Active",
                    "Ongoing",
                    "Completed",
                    "Expired"
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("db403555-56b7-488e-adc5-7df25c4a0344"), null, null, "Test position 1" },
                    { new Guid("03b195de-45a3-44bd-970b-7beead999695"), null, null, "Test position 2" },
                    { new Guid("dba22efb-5054-4ba0-b3b0-fbe82a6eefa2"), null, null, "Test position 3" },
                    { new Guid("73ea8042-726b-4d05-bb2f-e95d6fefdcbb"), null, null, "Test position 4" },
                    { new Guid("dac7c287-5740-4480-9c24-e619451c2a42"), null, null, "Test position 5" },
                    { new Guid("abcdf883-6f79-443a-a5cb-34e2e3a2d614"), null, null, "Test position 6" },
                    { new Guid("52682b24-4214-4f94-9bdd-b7bcd49b8ce7"), null, null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_StateValue",
                table: "JobOffers",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerJobOffers_JobOfferId",
                table: "ConsumerJobOffers",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_JobOfferStates_StateValue",
                table: "JobOffers",
                column: "StateValue",
                principalTable: "JobOfferStates",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
