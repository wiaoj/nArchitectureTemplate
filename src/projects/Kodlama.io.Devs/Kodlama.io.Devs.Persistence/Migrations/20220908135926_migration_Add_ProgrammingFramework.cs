using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class migration_Add_ProgrammingFramework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingFrameworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammingLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingFrameworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingFrameworks_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingFrameworks_ProgrammingLanguageId",
                table: "ProgrammingFrameworks",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingFrameworks");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
