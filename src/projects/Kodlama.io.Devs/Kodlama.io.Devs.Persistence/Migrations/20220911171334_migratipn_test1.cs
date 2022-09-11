using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class migratipn_test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a921122e-6f50-4128-8fdf-8ad11bba3656"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("2241c8f5-24c9-4922-ac87-c4f541baa745"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("5df28235-f573-42e2-acc5-c56b7ad6440e"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("617663e5-62a2-47ac-817e-c727b63edfde"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("63fa246d-62ff-4f60-80b2-a2379dcc8fbb"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("a68f8594-8b91-4059-8236-c8d123d1b3ca"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("cecdf6ca-8a64-4a48-805b-391ccc3fabd1"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("94c64181-4374-4147-869a-80d06bda2360"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("0da5e8ea-c337-446c-b176-b42608ad87b3"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("39366eae-6015-4c56-91cd-70d5a91af68b"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("da858610-8401-43be-a247-13004de7265d"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("824f279c-3efb-4a37-881a-b4fd97dc0f24"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0622b35b-9ac5-46d9-9d16-35892e6eb62e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1a4b5347-e654-41d4-9fc7-481b1a7c91f3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3168a31e-d7f7-4dff-8fb7-d1b0a7e68400"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41921fb4-cb61-497b-a564-4afcea49b0e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingFrameworks",
                columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { new Guid("12a8f25d-60c6-401a-88f0-606620777f19"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("41921fb4-cb61-497b-a564-4afcea49b0e4"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { new Guid("5ed3cb61-1a2f-484a-afb4-ecff84aedec9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("0622b35b-9ac5-46d9-9d16-35892e6eb62e"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { new Guid("984ad2c0-be13-4d0a-bed2-f5572fe77ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("41921fb4-cb61-497b-a564-4afcea49b0e4"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { new Guid("b1b9e9a0-3ebe-409f-b7c0-5b8702811adb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("3168a31e-d7f7-4dff-8fb7-d1b0a7e68400"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 },
                    { new Guid("c715db20-bc5d-4fcd-a4ab-ee7d8bfe61f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("3168a31e-d7f7-4dff-8fb7-d1b0a7e68400"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                    { new Guid("cc3fd3b5-6406-40f2-b62b-9451251e8710"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("0622b35b-9ac5-46d9-9d16-35892e6eb62e"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("824f279c-3efb-4a37-881a-b4fd97dc0f24"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("12a8f25d-60c6-401a-88f0-606620777f19"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("5ed3cb61-1a2f-484a-afb4-ecff84aedec9"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("984ad2c0-be13-4d0a-bed2-f5572fe77ed6"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("b1b9e9a0-3ebe-409f-b7c0-5b8702811adb"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("c715db20-bc5d-4fcd-a4ab-ee7d8bfe61f8"));

            migrationBuilder.DeleteData(
                table: "ProgrammingFrameworks",
                keyColumn: "Id",
                keyValue: new Guid("cc3fd3b5-6406-40f2-b62b-9451251e8710"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("1a4b5347-e654-41d4-9fc7-481b1a7c91f3"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("0622b35b-9ac5-46d9-9d16-35892e6eb62e"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("3168a31e-d7f7-4dff-8fb7-d1b0a7e68400"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41921fb4-cb61-497b-a564-4afcea49b0e4"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("a921122e-6f50-4128-8fdf-8ad11bba3656"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0da5e8ea-c337-446c-b176-b42608ad87b3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39366eae-6015-4c56-91cd-70d5a91af68b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94c64181-4374-4147-869a-80d06bda2360"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da858610-8401-43be-a247-13004de7265d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingFrameworks",
                columns: new[] { "Id", "CreatedDate", "Name", "ProgrammingLanguageId", "Tag", "UpdatedDate", "Version" },
                values: new object[,]
                {
                    { new Guid("2241c8f5-24c9-4922-ac87-c4f541baa745"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JSP", new Guid("0da5e8ea-c337-446c-b176-b42608ad87b3"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { new Guid("5df28235-f573-42e2-acc5-c56b7ad6440e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React", new Guid("da858610-8401-43be-a247-13004de7265d"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 },
                    { new Guid("617663e5-62a2-47ac-817e-c727b63edfde"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring", new Guid("0da5e8ea-c337-446c-b176-b42608ad87b3"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 },
                    { new Guid("63fa246d-62ff-4f60-80b2-a2379dcc8fbb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", new Guid("da858610-8401-43be-a247-13004de7265d"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.0 },
                    { new Guid("a68f8594-8b91-4059-8236-c8d123d1b3ca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WPF", new Guid("39366eae-6015-4c56-91cd-70d5a91af68b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0 },
                    { new Guid("cecdf6ca-8a64-4a48-805b-391ccc3fabd1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", new Guid("39366eae-6015-4c56-91cd-70d5a91af68b"), "latest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0 }
                });
        }
    }
}
