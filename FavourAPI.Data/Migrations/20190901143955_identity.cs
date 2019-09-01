using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProviders_Users_Id",
                table: "CompanyProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Users_Id",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMys_Users_Id",
                table: "PermissionMys");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionTransactions_Users_UserId",
                table: "PermissionTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProviders_Users_Id",
                table: "PersonProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

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

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProviders_AspNetUsers_Id",
                table: "CompanyProviders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_AspNetUsers_Id",
                table: "Consumers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMys_AspNetUsers_Id",
                table: "PermissionMys",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetUsers_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionTransactions_AspNetUsers_UserId",
                table: "PermissionTransactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProviders_AspNetUsers_Id",
                table: "PersonProviders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProviders_AspNetUsers_Id",
                table: "CompanyProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_AspNetUsers_Id",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMys_AspNetUsers_Id",
                table: "PermissionMys");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetUsers_UserId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionTransactions_AspNetUsers_UserId",
                table: "PermissionTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProviders_AspNetUsers_Id",
                table: "PersonProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "Users",
                newName: "Password");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

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
                    { new Guid("52682b24-4214-4f94-9bdd-b7bcd49b8ce7"), null, null, "Test position 7" },
                    { new Guid("abcdf883-6f79-443a-a5cb-34e2e3a2d614"), null, null, "Test position 6" },
                    { new Guid("dac7c287-5740-4480-9c24-e619451c2a42"), null, null, "Test position 5" },
                    { new Guid("03b195de-45a3-44bd-970b-7beead999695"), null, null, "Test position 2" },
                    { new Guid("dba22efb-5054-4ba0-b3b0-fbe82a6eefa2"), null, null, "Test position 3" },
                    { new Guid("db403555-56b7-488e-adc5-7df25c4a0344"), null, null, "Test position 1" },
                    { new Guid("73ea8042-726b-4d05-bb2f-e95d6fefdcbb"), null, null, "Test position 4" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProviders_Users_Id",
                table: "CompanyProviders",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Users_Id",
                table: "Consumers",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMys_Users_Id",
                table: "PermissionMys",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionTransactions_Users_UserId",
                table: "PermissionTransactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProviders_Users_Id",
                table: "PersonProviders",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
