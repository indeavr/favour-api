using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class educationseducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("0bde52da-8c4c-4fef-9381-48eb3139aa13"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("0c1fed62-ac00-486b-964c-b2a8adcf8954"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("57da91d8-86b4-4814-9203-e04b9ddbdb59"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a068f373-bc7e-45be-8768-b9bb5690175b"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a47378e8-20c7-45f5-a451-5c8b3aa8ef08"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("ccc69dc8-5231-4c01-a452-2efec093c5d3"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d4ab85bf-ed88-4188-a20a-c86caca9d5ec"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e36ca0b9-48c8-449e-bc50-73f576336710"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e62851e1-8ee5-4504-8e6e-7cd8027d04b6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("39c8f25b-75ed-4b16-bcc3-4a043efe41e5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("423d3b42-0b31-4deb-bc49-d29d051b143d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7730f416-7eeb-439a-9eff-588a38b5ea32"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("79e4dd6a-5088-4c38-b7b3-d1e529a4351a"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a8ccb9d7-bc32-4336-81b1-90184308ba84"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b5483fbd-2311-41dd-a9e1-de03e37a2b26"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d3a65080-00a5-4f62-b625-7cace455f5e2"));

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("d31ac721-65f1-42ce-b64b-41ba6c244a33"), null, "Test industry 1" },
                    { new Guid("04689ec3-e820-4f8b-8cd1-db03d779f981"), null, "Test industry 2" },
                    { new Guid("a165c1be-4c0b-4cdb-800f-e85f1bc19051"), null, "Test industry 3" },
                    { new Guid("54f63b6e-3db7-4894-9240-eb9638031bdf"), null, "Test industry 4" },
                    { new Guid("7e68df07-31e4-4e85-8b99-69125731aff3"), null, "Test industry 5" },
                    { new Guid("26895ddc-18f5-4b8e-911f-546ef0df530c"), null, "Test industry 6" },
                    { new Guid("bbb3ec51-80d0-4cee-8ab6-758fdcdac141"), null, "Test industry 7" },
                    { new Guid("f6d161e9-38d5-43fb-a933-395bf635eab5"), null, "Test industry 8" },
                    { new Guid("d9260bce-0d36-4561-b4fc-28b9a7fd35c4"), null, "Test industry 9" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("d4ab85bf-ed88-4188-a20a-c86caca9d5ec"), null, "Test industry 1" },
                    { new Guid("0bde52da-8c4c-4fef-9381-48eb3139aa13"), null, "Test industry 2" },
                    { new Guid("a47378e8-20c7-45f5-a451-5c8b3aa8ef08"), null, "Test industry 3" },
                    { new Guid("a068f373-bc7e-45be-8768-b9bb5690175b"), null, "Test industry 4" },
                    { new Guid("e62851e1-8ee5-4504-8e6e-7cd8027d04b6"), null, "Test industry 5" },
                    { new Guid("e36ca0b9-48c8-449e-bc50-73f576336710"), null, "Test industry 6" },
                    { new Guid("57da91d8-86b4-4814-9203-e04b9ddbdb59"), null, "Test industry 7" },
                    { new Guid("ccc69dc8-5231-4c01-a452-2efec093c5d3"), null, "Test industry 8" },
                    { new Guid("0c1fed62-ac00-486b-964c-b2a8adcf8954"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("a8ccb9d7-bc32-4336-81b1-90184308ba84"), null, null, "Test position 1" },
                    { new Guid("423d3b42-0b31-4deb-bc49-d29d051b143d"), null, null, "Test position 2" },
                    { new Guid("39c8f25b-75ed-4b16-bcc3-4a043efe41e5"), null, null, "Test position 3" },
                    { new Guid("7730f416-7eeb-439a-9eff-588a38b5ea32"), null, null, "Test position 4" },
                    { new Guid("b5483fbd-2311-41dd-a9e1-de03e37a2b26"), null, null, "Test position 5" },
                    { new Guid("d3a65080-00a5-4f62-b625-7cace455f5e2"), null, null, "Test position 6" },
                    { new Guid("79e4dd6a-5088-4c38-b7b3-d1e529a4351a"), null, null, "Test position 7" }
                });
        }
    }
}
