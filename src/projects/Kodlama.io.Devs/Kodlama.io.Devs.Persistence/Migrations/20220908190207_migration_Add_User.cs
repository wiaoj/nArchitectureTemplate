using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class migration_Add_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("3736a4d6-01fa-469a-abac-08d5ddccf816"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("42eb05df-1030-4d63-9403-ff8fc536be74"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("4fd5811e-054e-438d-bfb9-5e23b7ec573d"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("9168cfb9-2aed-49ba-bff0-9ced2bb596e1"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("b0d11d3e-515a-4ab6-8a7a-be1c74a0d361"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("ff132881-efc8-4e8d-b09b-bc1ab65b80e5"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("c61c9e34-d71d-490d-9b8c-4d65faafb306"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("d5fd9fd6-7aa9-466f-a5d6-6ad7e0f7ad84"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("e29b0bfb-283c-41f0-96b0-95fde5151544"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("e29e755d-3b06-4c93-90e7-5b7881277eea"));

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0f1723b0-143d-4131-9fc1-8ce634411a50"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("258fb3ab-0966-4a8b-900d-1d8da305fb82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ecf6e59-8aee-4810-83a8-e2f174b742a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("feed2285-5fd8-46c3-8fe4-f1656db8061b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingFrameworks",
                columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { new Guid("2b612468-892f-4bba-8fef-5c789296a962"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("7ecf6e59-8aee-4810-83a8-e2f174b742a1"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { new Guid("6c8c57c1-621a-48bb-a020-37a9ffaf2307"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("feed2285-5fd8-46c3-8fe4-f1656db8061b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                    { new Guid("73bfd3cb-be1c-4b66-aa36-1ad32b97e8cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("258fb3ab-0966-4a8b-900d-1d8da305fb82"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { new Guid("8e289101-8d88-4832-9afa-1c9c97571a6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("258fb3ab-0966-4a8b-900d-1d8da305fb82"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { new Guid("9d2e5665-73c0-438e-a1b0-131746dec50a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("7ecf6e59-8aee-4810-83a8-e2f174b742a1"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { new Guid("a43e5e4c-3566-4131-93f7-dec2e561aeea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("feed2285-5fd8-46c3-8fe4-f1656db8061b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("2b612468-892f-4bba-8fef-5c789296a962"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("6c8c57c1-621a-48bb-a020-37a9ffaf2307"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("73bfd3cb-be1c-4b66-aa36-1ad32b97e8cd"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("8e289101-8d88-4832-9afa-1c9c97571a6b"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("9d2e5665-73c0-438e-a1b0-131746dec50a"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("a43e5e4c-3566-4131-93f7-dec2e561aeea"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("0f1723b0-143d-4131-9fc1-8ce634411a50"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("258fb3ab-0966-4a8b-900d-1d8da305fb82"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("7ecf6e59-8aee-4810-83a8-e2f174b742a1"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("feed2285-5fd8-46c3-8fe4-f1656db8061b"));

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c61c9e34-d71d-490d-9b8c-4d65faafb306"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5fd9fd6-7aa9-466f-a5d6-6ad7e0f7ad84"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e29b0bfb-283c-41f0-96b0-95fde5151544"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e29e755d-3b06-4c93-90e7-5b7881277eea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingFrameworks",
                columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { new Guid("3736a4d6-01fa-469a-abac-08d5ddccf816"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("d5fd9fd6-7aa9-466f-a5d6-6ad7e0f7ad84"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                    { new Guid("42eb05df-1030-4d63-9403-ff8fc536be74"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("e29e755d-3b06-4c93-90e7-5b7881277eea"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { new Guid("4fd5811e-054e-438d-bfb9-5e23b7ec573d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("d5fd9fd6-7aa9-466f-a5d6-6ad7e0f7ad84"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 },
                    { new Guid("9168cfb9-2aed-49ba-bff0-9ced2bb596e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("e29b0bfb-283c-41f0-96b0-95fde5151544"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { new Guid("b0d11d3e-515a-4ab6-8a7a-be1c74a0d361"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("e29e755d-3b06-4c93-90e7-5b7881277eea"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { new Guid("ff132881-efc8-4e8d-b09b-bc1ab65b80e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("e29b0bfb-283c-41f0-96b0-95fde5151544"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 }
                });
        }
    }
}
