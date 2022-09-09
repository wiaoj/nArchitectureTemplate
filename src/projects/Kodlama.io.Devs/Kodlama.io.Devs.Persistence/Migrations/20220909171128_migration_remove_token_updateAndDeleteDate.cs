using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class migration_remove_token_updateAndDeleteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RefreshTokens");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("9135026a-fa5f-47af-a6ca-24d73cdccc4e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("55c8415a-3cfe-4f6b-a3f5-2adb85c48487"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99c389e2-d41b-4b2f-bdb4-afbaa0bb2f6e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1e20847-187d-47e7-9f2c-c275882b5210"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0b0ea34-6f78-4941-8c1c-ce69d3521ec8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingFrameworks",
                columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { new Guid("189d70ac-b24e-4977-a88a-61d585a56f76"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("a1e20847-187d-47e7-9f2c-c275882b5210"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                    { new Guid("1af19670-0a8d-4319-963f-bab023192109"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("d0b0ea34-6f78-4941-8c1c-ce69d3521ec8"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 },
                    { new Guid("b9189fbf-5f03-4196-bc18-9b5efcf7ba34"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("d0b0ea34-6f78-4941-8c1c-ce69d3521ec8"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                    { new Guid("b9402bd9-f346-4687-ac66-59fb4945e872"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("99c389e2-d41b-4b2f-bdb4-afbaa0bb2f6e"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { new Guid("cdf64f13-092c-465e-a414-076350771511"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("99c389e2-d41b-4b2f-bdb4-afbaa0bb2f6e"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { new Guid("f6b7cf7a-b9db-4883-b344-8df487c53538"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("a1e20847-187d-47e7-9f2c-c275882b5210"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9135026a-fa5f-47af-a6ca-24d73cdccc4e"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("189d70ac-b24e-4977-a88a-61d585a56f76"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("1af19670-0a8d-4319-963f-bab023192109"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("b9189fbf-5f03-4196-bc18-9b5efcf7ba34"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("b9402bd9-f346-4687-ac66-59fb4945e872"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("cdf64f13-092c-465e-a414-076350771511"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("f6b7cf7a-b9db-4883-b344-8df487c53538"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("55c8415a-3cfe-4f6b-a3f5-2adb85c48487"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("99c389e2-d41b-4b2f-bdb4-afbaa0bb2f6e"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("a1e20847-187d-47e7-9f2c-c275882b5210"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("d0b0ea34-6f78-4941-8c1c-ce69d3521ec8"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
