using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class educationfieldOfStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("08fa6477-205c-47d8-bca5-32653e8bc092"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("24906b82-3665-4405-89e1-1beef734964e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("31649137-c730-440a-adf9-66408d40e0b5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("59cd3ae8-80b1-4bbf-8877-65bab77a6886"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7d97fe69-40dc-4f58-8805-7419c8aa0068"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("9b66ffce-2380-4e5d-8575-ef450fbe3a57"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a71d6fdc-94ea-468f-948a-af5238aca71c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a9f33af7-b07b-48bd-9642-f893ad5950fe"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("ccdb8e70-fc1a-4b5b-85e7-3c81f2f6bb3e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("351c4899-2df1-4bfb-99e0-b3add2f980b0"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("45be74d3-425d-4b35-84f7-d0d0be667421"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("84ab9449-cc67-4759-a87b-e6e21b548f58"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a72443c7-d61d-4ce9-bb6e-a6796cec9ce3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d3113932-28bf-4069-a81f-f11e14060440"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("dc5171a2-5725-499d-9b08-3c2f608f7472"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ecbe3889-3f30-4149-b466-e9771cd5f13c"));

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("356e4425-3c4c-42e1-a741-75de8b2a6bc3"), null, "Test industry 1" },
                    { new Guid("cde0eed9-b15b-438a-9e4e-9f9537c9ad5a"), null, "Test industry 2" },
                    { new Guid("3c4f76c4-cbcf-4120-b268-4272978f4bd7"), null, "Test industry 3" },
                    { new Guid("483c1e5a-2320-42af-b904-b4bc1e6ea274"), null, "Test industry 4" },
                    { new Guid("932dbff0-f73b-4a34-811b-ef9feef0d6e7"), null, "Test industry 5" },
                    { new Guid("1188241b-5ceb-471e-97b8-99c38fbb4eeb"), null, "Test industry 6" },
                    { new Guid("af245469-c800-4a2d-9fb2-94159e7b60a5"), null, "Test industry 7" },
                    { new Guid("4692675c-7d03-457a-9741-058c98499f29"), null, "Test industry 8" },
                    { new Guid("e2c87cd6-a7dc-4018-b076-e7b195b82aa8"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("09b4b37e-5769-421d-aff5-7c09de74f687"), null, "Test position 1" },
                    { new Guid("3c6b8345-e661-46cb-ad48-ec7ed502cf7b"), null, "Test position 2" },
                    { new Guid("fd953fb3-d301-4fde-a0e2-7d33c3efcf5d"), null, "Test position 3" },
                    { new Guid("0e6d5136-3170-4aee-a682-fa00806c61b8"), null, "Test position 4" },
                    { new Guid("93270c14-315b-439d-ab14-eb4817689026"), null, "Test position 5" },
                    { new Guid("065bf4c2-1713-4c02-b4ba-25a41ddcfde0"), null, "Test position 6" },
                    { new Guid("9e516698-9e8b-4be1-84bf-d528c63fbf32"), null, "Test position 7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("1188241b-5ceb-471e-97b8-99c38fbb4eeb"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("356e4425-3c4c-42e1-a741-75de8b2a6bc3"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("3c4f76c4-cbcf-4120-b268-4272978f4bd7"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("4692675c-7d03-457a-9741-058c98499f29"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("483c1e5a-2320-42af-b904-b4bc1e6ea274"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("932dbff0-f73b-4a34-811b-ef9feef0d6e7"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("af245469-c800-4a2d-9fb2-94159e7b60a5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("cde0eed9-b15b-438a-9e4e-9f9537c9ad5a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e2c87cd6-a7dc-4018-b076-e7b195b82aa8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("065bf4c2-1713-4c02-b4ba-25a41ddcfde0"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("09b4b37e-5769-421d-aff5-7c09de74f687"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0e6d5136-3170-4aee-a682-fa00806c61b8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3c6b8345-e661-46cb-ad48-ec7ed502cf7b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("93270c14-315b-439d-ab14-eb4817689026"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9e516698-9e8b-4be1-84bf-d528c63fbf32"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fd953fb3-d301-4fde-a0e2-7d33c3efcf5d"));

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("ccdb8e70-fc1a-4b5b-85e7-3c81f2f6bb3e"), null, "Test industry 1" },
                    { new Guid("31649137-c730-440a-adf9-66408d40e0b5"), null, "Test industry 2" },
                    { new Guid("a9f33af7-b07b-48bd-9642-f893ad5950fe"), null, "Test industry 3" },
                    { new Guid("a71d6fdc-94ea-468f-948a-af5238aca71c"), null, "Test industry 4" },
                    { new Guid("59cd3ae8-80b1-4bbf-8877-65bab77a6886"), null, "Test industry 5" },
                    { new Guid("08fa6477-205c-47d8-bca5-32653e8bc092"), null, "Test industry 6" },
                    { new Guid("9b66ffce-2380-4e5d-8575-ef450fbe3a57"), null, "Test industry 7" },
                    { new Guid("24906b82-3665-4405-89e1-1beef734964e"), null, "Test industry 8" },
                    { new Guid("7d97fe69-40dc-4f58-8805-7419c8aa0068"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("ecbe3889-3f30-4149-b466-e9771cd5f13c"), null, "Test position 1" },
                    { new Guid("a72443c7-d61d-4ce9-bb6e-a6796cec9ce3"), null, "Test position 2" },
                    { new Guid("45be74d3-425d-4b35-84f7-d0d0be667421"), null, "Test position 3" },
                    { new Guid("d3113932-28bf-4069-a81f-f11e14060440"), null, "Test position 4" },
                    { new Guid("84ab9449-cc67-4759-a87b-e6e21b548f58"), null, "Test position 5" },
                    { new Guid("351c4899-2df1-4bfb-99e0-b3add2f980b0"), null, "Test position 6" },
                    { new Guid("dc5171a2-5725-499d-9b08-3c2f608f7472"), null, "Test position 7" }
                });
        }
    }
}
