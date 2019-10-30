using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class addedOrderToIndustry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("12ca432e-af3a-49c7-bc2e-cd6f61ae5694"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("27eea4dd-ec56-4f7b-9d75-8dacde4df532"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("2b87ad48-5299-4ab1-94c9-5698551c9f56"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("3222cc30-0f8b-4264-9d9b-040ecdea8b6e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("4f7d2fc5-1be8-4316-9f99-d24766bed1c6"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("69e5cce5-704f-4b2b-a8bc-dc7d3b77b67e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("6fc0db2f-f80a-4c38-b1b5-ae16574d9d84"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("adfa62ad-a201-44d6-b315-a2e13b27f0f9"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e28e3822-6952-495c-baf7-618eec97f776"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0f149d0d-8134-473b-b2f1-6a5e3a5c5cf7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("193fac19-7659-4425-a0e8-845e055964ca"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("61140fbc-7355-4b3d-95f0-9fef8551a3b3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7094f8e5-c506-4892-abf1-927d1ffc80cf"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7b5258b6-aa60-46d1-86d6-99ccddb7dc0e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("931abee7-6944-4ef2-b614-3bc94a44589b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e36b55d6-0790-45ac-940e-b6647a11cfc4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 1");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 2");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 3");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 4");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 5");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Industries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Industries");

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("e28e3822-6952-495c-baf7-618eec97f776"), null, "Test industry 1" },
                    { new Guid("12ca432e-af3a-49c7-bc2e-cd6f61ae5694"), null, "Test industry 2" },
                    { new Guid("4f7d2fc5-1be8-4316-9f99-d24766bed1c6"), null, "Test industry 3" },
                    { new Guid("27eea4dd-ec56-4f7b-9d75-8dacde4df532"), null, "Test industry 4" },
                    { new Guid("3222cc30-0f8b-4264-9d9b-040ecdea8b6e"), null, "Test industry 5" },
                    { new Guid("adfa62ad-a201-44d6-b315-a2e13b27f0f9"), null, "Test industry 6" },
                    { new Guid("6fc0db2f-f80a-4c38-b1b5-ae16574d9d84"), null, "Test industry 7" },
                    { new Guid("69e5cce5-704f-4b2b-a8bc-dc7d3b77b67e"), null, "Test industry 8" },
                    { new Guid("2b87ad48-5299-4ab1-94c9-5698551c9f56"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "ConsumerId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("7094f8e5-c506-4892-abf1-927d1ffc80cf"), null, null, null, "Test position 7" },
                    { new Guid("7b5258b6-aa60-46d1-86d6-99ccddb7dc0e"), null, null, null, "Test position 6" },
                    { new Guid("61140fbc-7355-4b3d-95f0-9fef8551a3b3"), null, null, null, "Test position 5" },
                    { new Guid("193fac19-7659-4425-a0e8-845e055964ca"), null, null, null, "Test position 2" },
                    { new Guid("0f149d0d-8134-473b-b2f1-6a5e3a5c5cf7"), null, null, null, "Test position 3" },
                    { new Guid("e36b55d6-0790-45ac-940e-b6647a11cfc4"), null, null, null, "Test position 1" },
                    { new Guid("931abee7-6944-4ef2-b614-3bc94a44589b"), null, null, null, "Test position 4" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "ConsumerId", "JobOfferId" },
                values: new object[,]
                {
                    { "Test skill 4", null, null },
                    { "Test skill 1", null, null },
                    { "Test skill 2", null, null },
                    { "Test skill 3", null, null },
                    { "Test skill 5", null, null }
                });
        }
    }
}
