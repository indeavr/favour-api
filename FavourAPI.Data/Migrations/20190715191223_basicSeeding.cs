using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class basicSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("48ffce08-54ed-4c5c-9b9c-79300f297098"), null, "Test industry 1" },
                    { new Guid("a0066260-96e9-49bc-aa2b-6fdffe00482c"), null, "Test industry 2" },
                    { new Guid("e9a2ddf7-9450-4f15-952f-f2fa717e4f5c"), null, "Test industry 3" },
                    { new Guid("f67736a5-d6a1-44b6-859c-480c3726192b"), null, "Test industry 4" },
                    { new Guid("1478f59a-a2b1-485a-bef5-f1c7025cf358"), null, "Test industry 5" },
                    { new Guid("67f03807-e019-4df2-b9b7-7129bc65e876"), null, "Test industry 6" },
                    { new Guid("6076e068-1588-4b6b-ba01-182f743b033d"), null, "Test industry 7" },
                    { new Guid("db4f5b7f-2c52-4852-bdf7-36529946fa9b"), null, "Test industry 8" },
                    { new Guid("931092ff-e7c0-4698-b4be-4ca258cc4ec4"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("b46e6e07-a7b6-472b-9a1d-7429f3797202"), null, "Test position 1" },
                    { new Guid("d567b94b-3689-453c-af9a-f79be23c2933"), null, "Test position 7" },
                    { new Guid("41116f1e-b861-41a7-8b12-1bddf27c2088"), null, "Test position 6" },
                    { new Guid("d645894b-7820-4bcd-85f4-7bec4ba190f2"), null, "Test position 2" },
                    { new Guid("b4728651-382d-4d3d-96c2-a93cbd72e980"), null, "Test position 3" },
                    { new Guid("b21037fe-57bd-4b3d-bdb5-e9553dd60531"), null, "Test position 4" },
                    { new Guid("40889d94-f0dd-46b4-b7f3-dded74735e07"), null, "Test position 5" }
                });

            migrationBuilder.InsertData(
                table: "Sexes",
                column: "Value",
                values: new object[]
                {
                    "Male",
                    "Female"
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "ConsumerId", "JobOfferId" },
                values: new object[,]
                {
                    { "Test skill 1", null, null },
                    { "Test skill 2", null, null },
                    { "Test skill 3", null, null },
                    { "Test skill 4", null, null },
                    { "Test skill 5", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("1478f59a-a2b1-485a-bef5-f1c7025cf358"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("48ffce08-54ed-4c5c-9b9c-79300f297098"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("6076e068-1588-4b6b-ba01-182f743b033d"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("67f03807-e019-4df2-b9b7-7129bc65e876"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("931092ff-e7c0-4698-b4be-4ca258cc4ec4"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a0066260-96e9-49bc-aa2b-6fdffe00482c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("db4f5b7f-2c52-4852-bdf7-36529946fa9b"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e9a2ddf7-9450-4f15-952f-f2fa717e4f5c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("f67736a5-d6a1-44b6-859c-480c3726192b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("40889d94-f0dd-46b4-b7f3-dded74735e07"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("41116f1e-b861-41a7-8b12-1bddf27c2088"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b21037fe-57bd-4b3d-bdb5-e9553dd60531"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b46e6e07-a7b6-472b-9a1d-7429f3797202"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b4728651-382d-4d3d-96c2-a93cbd72e980"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d567b94b-3689-453c-af9a-f79be23c2933"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d645894b-7820-4bcd-85f4-7bec4ba190f2"));

            migrationBuilder.DeleteData(
                table: "Sexes",
                keyColumn: "Value",
                keyValue: "Female");

            migrationBuilder.DeleteData(
                table: "Sexes",
                keyColumn: "Value",
                keyValue: "Male");

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
        }
    }
}
