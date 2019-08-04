using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class ManyConsumeresForOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedJobOffers_Results_ResultId",
                table: "CompletedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_JobOffers_Id",
                table: "OngoingJobOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OngoingJobOffers",
                table: "OngoingJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_OngoingJobOffers_ConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_CompletedJobOffers_ResultId",
                table: "CompletedJobOffers");

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
                name: "ResultId",
                table: "CompletedJobOffers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OngoingJobOffers",
                newName: "JobOfferId");

            migrationBuilder.AddColumn<Guid>(
                name: "CompletedJobOfferId",
                table: "Results",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "OngoingJobOffers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OngoingJobOffers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActiveJobOffers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OngoingJobOffers",
                table: "OngoingJobOffers",
                columns: new[] { "ConsumerId", "JobOfferId" });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("36c26a60-a276-44d2-b7dc-74bdadc147af"), null, "Test industry 1" },
                    { new Guid("d9c03e7c-0d7a-4f83-82bd-8b1fea577859"), null, "Test industry 2" },
                    { new Guid("bb807399-d35c-4944-801d-d3a371a08d8e"), null, "Test industry 3" },
                    { new Guid("13b08251-8304-43b4-9345-b6af35122b00"), null, "Test industry 4" },
                    { new Guid("e44d1159-ee89-494a-8658-411b2cfe0ea6"), null, "Test industry 5" },
                    { new Guid("b06b1408-e7cd-4d6f-9bd8-c632ebfcebd7"), null, "Test industry 6" },
                    { new Guid("149768a4-c6e8-4eb3-b939-38f35cf3c5ba"), null, "Test industry 7" },
                    { new Guid("10786b67-1bf7-4462-bcd6-763cb7531a34"), null, "Test industry 8" },
                    { new Guid("7178aea7-60e6-4877-8bbf-5ca88bf030e5"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("f26695a4-34f2-42fa-bfca-ef80b1526f14"), null, null, "Test position 1" },
                    { new Guid("0b43d3eb-c943-462e-8922-2e7c3ad224a3"), null, null, "Test position 2" },
                    { new Guid("fbf77dd7-c056-448d-a103-a39c88b2a935"), null, null, "Test position 3" },
                    { new Guid("754c1a2f-834f-44c7-8af7-de3c6be86c7d"), null, null, "Test position 4" },
                    { new Guid("c3ee903a-3a5a-4ea2-9389-04ca3a2ad1d1"), null, null, "Test position 5" },
                    { new Guid("50a0e256-62ef-4691-a14b-37e4ff790967"), null, null, "Test position 6" },
                    { new Guid("1fb6e675-5474-4b5c-9584-513f81861b5d"), null, null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_CompletedJobOfferId",
                table: "Results",
                column: "CompletedJobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingJobOffers_JobOfferId",
                table: "OngoingJobOffers",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                table: "OngoingJobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_JobOffers_JobOfferId",
                table: "OngoingJobOffers",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_CompletedJobOffers_CompletedJobOfferId",
                table: "Results",
                column: "CompletedJobOfferId",
                principalTable: "CompletedJobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_JobOffers_JobOfferId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_CompletedJobOffers_CompletedJobOfferId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_CompletedJobOfferId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OngoingJobOffers",
                table: "OngoingJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_OngoingJobOffers_JobOfferId",
                table: "OngoingJobOffers");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("10786b67-1bf7-4462-bcd6-763cb7531a34"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("13b08251-8304-43b4-9345-b6af35122b00"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("149768a4-c6e8-4eb3-b939-38f35cf3c5ba"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("36c26a60-a276-44d2-b7dc-74bdadc147af"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7178aea7-60e6-4877-8bbf-5ca88bf030e5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("b06b1408-e7cd-4d6f-9bd8-c632ebfcebd7"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("bb807399-d35c-4944-801d-d3a371a08d8e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d9c03e7c-0d7a-4f83-82bd-8b1fea577859"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e44d1159-ee89-494a-8658-411b2cfe0ea6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0b43d3eb-c943-462e-8922-2e7c3ad224a3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1fb6e675-5474-4b5c-9584-513f81861b5d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("50a0e256-62ef-4691-a14b-37e4ff790967"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("754c1a2f-834f-44c7-8af7-de3c6be86c7d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("c3ee903a-3a5a-4ea2-9389-04ca3a2ad1d1"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f26695a4-34f2-42fa-bfca-ef80b1526f14"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fbf77dd7-c056-448d-a103-a39c88b2a935"));

            migrationBuilder.DropColumn(
                name: "CompletedJobOfferId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OngoingJobOffers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActiveJobOffers");

            migrationBuilder.RenameColumn(
                name: "JobOfferId",
                table: "OngoingJobOffers",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "OngoingJobOffers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ResultId",
                table: "CompletedJobOffers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OngoingJobOffers",
                table: "OngoingJobOffers",
                column: "Id");

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
                name: "IX_OngoingJobOffers_ConsumerId",
                table: "OngoingJobOffers",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedJobOffers_ResultId",
                table: "CompletedJobOffers",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedJobOffers_Results_ResultId",
                table: "CompletedJobOffers",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                table: "OngoingJobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_JobOffers_Id",
                table: "OngoingJobOffers",
                column: "Id",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
