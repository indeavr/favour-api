using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class permissionsystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleName",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleName", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueIdentifier", nullable: false),
                    Name1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_RoleName_Name1",
                        column: x => x.Name1,
                        principalTable: "RoleName",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionNames",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionNames", x => x.Name);
                    table.ForeignKey(
                        name: "FK_PermissionNames_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    CurrentCount = table.Column<int>(nullable: false),
                    PermissionNameName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionNames_PermissionNameName",
                        column: x => x.PermissionNameName,
                        principalTable: "PermissionNames",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MoneyPerItem = table.Column<double>(nullable: false),
                    PermissionName = table.Column<string>(nullable: true),
                    ItemCount = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionTransactions_PermissionNames_PermissionName",
                        column: x => x.PermissionName,
                        principalTable: "PermissionNames",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionTransactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionNames_RoleId",
                table: "PermissionNames",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionNameName",
                table: "Permissions",
                column: "PermissionNameName");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTransactions_PermissionName",
                table: "PermissionTransactions",
                column: "PermissionName");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTransactions_UserId",
                table: "PermissionTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name1",
                table: "Role",
                column: "Name1");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_RoleId",
                table: "Subscriptions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTransactions");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "PermissionNames");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleName");
        }
    }
}
