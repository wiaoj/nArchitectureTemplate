using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class migtest_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_User_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_User_UserId",
                table: "SocialLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

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

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_Users_UserId",
                table: "SocialLinks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_Users_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_Users_UserId",
                table: "SocialLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_Users_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

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

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "User",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_User_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_User_UserId",
                table: "SocialLinks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
