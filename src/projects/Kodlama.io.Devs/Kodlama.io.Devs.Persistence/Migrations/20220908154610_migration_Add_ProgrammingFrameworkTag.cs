using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class migration_Add_ProgrammingFrameworkTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("172c2d20-87a9-4630-8df9-4f7b3b7abcdd"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("18a808d4-e6e8-43e1-8436-77a453984b8f"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("1e0a92ad-5587-43f4-aab3-16015ddd7c3c"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("b2c82e84-c9c5-42ed-94bc-75e16e03cb62"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("e828273a-dbb0-4878-bd13-68c248951a84"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("f2c5f4ac-ecc6-4308-9987-2e2e8e141606"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("62d7a6c1-8c91-46a8-9146-892de5d06ba5"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("0f8cf33b-87ed-4b39-9675-4efe878c8faf"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("5c01272c-6ddd-4ce9-ab9f-443022795c6c"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bb0b3e42-2dec-4acf-8dbc-1f0fc5d16ec9"));

            migrationBuilder.AlterColumn<double>(
                name: "Version",
                table: "ProgrammingFrameworks",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "ProgrammingFrameworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "ProgrammingFrameworks");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "ProgrammingFrameworks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0f8cf33b-87ed-4b39-9675-4efe878c8faf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c01272c-6ddd-4ce9-ab9f-443022795c6c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("62d7a6c1-8c91-46a8-9146-892de5d06ba5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb0b3e42-2dec-4acf-8dbc-1f0fc5d16ec9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingFrameworks",
                columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { new Guid("172c2d20-87a9-4630-8df9-4f7b3b7abcdd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("bb0b3e42-2dec-4acf-8dbc-1f0fc5d16ec9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { new Guid("18a808d4-e6e8-43e1-8436-77a453984b8f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("5c01272c-6ddd-4ce9-ab9f-443022795c6c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { new Guid("1e0a92ad-5587-43f4-aab3-16015ddd7c3c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("0f8cf33b-87ed-4b39-9675-4efe878c8faf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { new Guid("b2c82e84-c9c5-42ed-94bc-75e16e03cb62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("5c01272c-6ddd-4ce9-ab9f-443022795c6c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { new Guid("e828273a-dbb0-4878-bd13-68c248951a84"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("0f8cf33b-87ed-4b39-9675-4efe878c8faf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { new Guid("f2c5f4ac-ecc6-4308-9987-2e2e8e141606"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("bb0b3e42-2dec-4acf-8dbc-1f0fc5d16ec9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" }
                });
        }
    }
}
