using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations;

public partial class migration_add_appuser : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.DeleteData(
            table: "OperationClaims",
            keyColumn: "Id",
            keyValue: new Guid("31ca4b0b-2f60-4272-a79c-2b023d3b027b"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("0eb3715b-e098-46de-b30e-a8c3887554e9"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("63281981-c364-4f2f-825d-ca1eb9a7fd5f"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("6c4a732f-1985-434a-9ab2-26225e440f6b"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("85c7751f-ebc5-47ea-9ca1-abfe5948d0a8"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("88cdd4b7-92e9-4a50-b941-ee449b2a56f3"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("89762b54-b5c6-4bad-98da-2066f37a24de"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("f7b9b3cb-7424-440d-8e0a-b364d1d9e9ec"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("4e2e1cdb-0564-4062-acc9-5e8f6e7a5eb8"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("a54d6a70-9acb-47f5-9853-bc59284a9e5b"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("b00a55ba-9703-4494-b3d7-47e301bad745"));

        migrationBuilder.InsertData(
            table: "OperationClaims",
            columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
            values: new object[] { new Guid("7a1987ce-f672-4c54-b822-56ec1ab26eaf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

        migrationBuilder.InsertData(
            table: "ProgrammingLanguages",
            columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
            values: new object[,]
            {
                { new Guid("1b806826-6c03-441f-9cff-911e59c5070a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                { new Guid("400d5bc1-353d-4403-8d45-c4a10080bf3b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                { new Guid("58185de4-8c9f-4bf7-891f-3b0e2816dc0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                { new Guid("815f4240-ce01-490d-b59a-3a8a03fb27d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
            });

        migrationBuilder.InsertData(
            table: "ProgrammingFrameworks",
            columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
            values: new object[,]
            {
                { new Guid("231c8ca7-0042-4aeb-87f0-6112a8bc4a60"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("58185de4-8c9f-4bf7-891f-3b0e2816dc0d"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                { new Guid("48d92287-023a-4a21-bd41-648a4f4b9cc4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("58185de4-8c9f-4bf7-891f-3b0e2816dc0d"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 },
                { new Guid("69dd7893-17ab-4624-98cc-962ec1dfa32a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("400d5bc1-353d-4403-8d45-c4a10080bf3b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                { new Guid("7ac3fff1-1dd4-41ee-aeb9-3ed6cbac2815"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("1b806826-6c03-441f-9cff-911e59c5070a"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                { new Guid("94c625d7-3843-4373-be17-28f81859f6b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("400d5bc1-353d-4403-8d45-c4a10080bf3b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                { new Guid("cb2f807f-f8c1-466b-9d45-4d1eb7c2ad36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("1b806826-6c03-441f-9cff-911e59c5070a"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 }
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DeleteData(
            table: "OperationClaims",
            keyColumn: "Id",
            keyValue: new Guid("7a1987ce-f672-4c54-b822-56ec1ab26eaf"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("231c8ca7-0042-4aeb-87f0-6112a8bc4a60"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("48d92287-023a-4a21-bd41-648a4f4b9cc4"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("69dd7893-17ab-4624-98cc-962ec1dfa32a"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("7ac3fff1-1dd4-41ee-aeb9-3ed6cbac2815"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("94c625d7-3843-4373-be17-28f81859f6b3"));

        migrationBuilder.DeleteData(
            table: "ProgrammingFrameworks",
            keyColumn: "Id",
            keyValue: new Guid("cb2f807f-f8c1-466b-9d45-4d1eb7c2ad36"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("815f4240-ce01-490d-b59a-3a8a03fb27d3"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("1b806826-6c03-441f-9cff-911e59c5070a"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("400d5bc1-353d-4403-8d45-c4a10080bf3b"));

        migrationBuilder.DeleteData(
            table: "ProgrammingLanguages",
            keyColumn: "Id",
            keyValue: new Guid("58185de4-8c9f-4bf7-891f-3b0e2816dc0d"));

        migrationBuilder.InsertData(
            table: "OperationClaims",
            columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
            values: new object[] { new Guid("31ca4b0b-2f60-4272-a79c-2b023d3b027b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

        migrationBuilder.InsertData(
            table: "ProgrammingLanguages",
            columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
            values: new object[,]
            {
                { new Guid("4e2e1cdb-0564-4062-acc9-5e8f6e7a5eb8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                { new Guid("a54d6a70-9acb-47f5-9853-bc59284a9e5b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                { new Guid("b00a55ba-9703-4494-b3d7-47e301bad745"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                { new Guid("f7b9b3cb-7424-440d-8e0a-b364d1d9e9ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
            });

        migrationBuilder.InsertData(
            table: "ProgrammingFrameworks",
            columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
            values: new object[,]
            {
                { new Guid("0eb3715b-e098-46de-b30e-a8c3887554e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("4e2e1cdb-0564-4062-acc9-5e8f6e7a5eb8"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                { new Guid("63281981-c364-4f2f-825d-ca1eb9a7fd5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("a54d6a70-9acb-47f5-9853-bc59284a9e5b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                { new Guid("6c4a732f-1985-434a-9ab2-26225e440f6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("b00a55ba-9703-4494-b3d7-47e301bad745"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 },
                { new Guid("85c7751f-ebc5-47ea-9ca1-abfe5948d0a8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("a54d6a70-9acb-47f5-9853-bc59284a9e5b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 },
                { new Guid("88cdd4b7-92e9-4a50-b941-ee449b2a56f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("b00a55ba-9703-4494-b3d7-47e301bad745"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                { new Guid("89762b54-b5c6-4bad-98da-2066f37a24de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("4e2e1cdb-0564-4062-acc9-5e8f6e7a5eb8"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 }
            });
    }
}
