using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations;

public partial class migration_Update_SocialLink : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.CreateTable(
            name: "OperationClaims",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_OperationClaims", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ProgrammingLanguages",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false),
                AuthenticatorType = table.Column<int>(type: "int", nullable: false),
                Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_User", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ProgrammingFrameworks",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Version = table.Column<double>(type: "float", nullable: false),
                Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ProgrammingLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_ProgrammingFrameworks", x => x.Id);
                table.ForeignKey(
                    name: "FK_ProgrammingFrameworks_ProgrammingLanguages_ProgrammingLanguageId",
                    column: x => x.ProgrammingLanguageId,
                    principalTable: "ProgrammingLanguages",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "RefreshTokens",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table => {
                table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                table.ForeignKey(
                    name: "FK_RefreshTokens_User_UserId",
                    column: x => x.UserId,
                    principalTable: "User",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "SocialLinks",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_SocialLinks", x => x.Id);
                table.ForeignKey(
                    name: "FK_SocialLinks_User_UserId",
                    column: x => x.UserId,
                    principalTable: "User",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "UserOperationClaims",
            columns: table => new {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                OperationClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => {
                table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                    column: x => x.OperationClaimId,
                    principalTable: "OperationClaims",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_UserOperationClaims_User_UserId",
                    column: x => x.UserId,
                    principalTable: "User",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

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

        migrationBuilder.CreateIndex(
            name: "IX_ProgrammingFrameworks_ProgrammingLanguageId",
            table: "ProgrammingFrameworks",
            column: "ProgrammingLanguageId");

        migrationBuilder.CreateIndex(
            name: "IX_RefreshTokens_UserId",
            table: "RefreshTokens",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_SocialLinks_UserId",
            table: "SocialLinks",
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

    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropTable(
            name: "ProgrammingFrameworks");

        migrationBuilder.DropTable(
            name: "RefreshTokens");

        migrationBuilder.DropTable(
            name: "SocialLinks");

        migrationBuilder.DropTable(
            name: "UserOperationClaims");

        migrationBuilder.DropTable(
            name: "ProgrammingLanguages");

        migrationBuilder.DropTable(
            name: "OperationClaims");

        migrationBuilder.DropTable(
            name: "User");
    }
}
