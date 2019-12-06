using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Binding.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dataAuthor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameAuthor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataAuthor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dataRegUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataRegUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dataBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameBook = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    TotalQuantity = table.Column<int>(nullable: false),
                    RealQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dataBook_dataAuthor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "dataAuthor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dataOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    BookName = table.Column<string>(nullable: true),
                    RegistrationId = table.Column<int>(nullable: false),
                    RegUserName = table.Column<string>(nullable: true),
                    DateOrder = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dataOrder_dataBook_BookId",
                        column: x => x.BookId,
                        principalTable: "dataBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dataOrder_dataRegUser_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "dataRegUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dataAuthor",
                columns: new[] { "Id", "NameAuthor" },
                values: new object[,]
                {
                    { 1, "Автор 1" },
                    { 2, "Автор 2" },
                    { 3, "Автор 3" }
                });

            migrationBuilder.InsertData(
                table: "dataRegUser",
                columns: new[] { "Id", "City", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Город 1", "ivanivan@gmail.com", "11111111", "Иван" },
                    { 2, "Город 2", "dimdim@gmail.com", "11111111", "Дмитрий" },
                    { 3, "Город 3", "alexandr@gmail.com", "11111111", "Александр" }
                });

            migrationBuilder.InsertData(
                table: "dataBook",
                columns: new[] { "Id", "AuthorId", "AuthorName", "NameBook", "RealQuantity", "TotalQuantity" },
                values: new object[] { 1, 1, "Автор", "Книга 1", 20, 20 });

            migrationBuilder.InsertData(
                table: "dataBook",
                columns: new[] { "Id", "AuthorId", "AuthorName", "NameBook", "RealQuantity", "TotalQuantity" },
                values: new object[] { 2, 2, "Автор 2", "Книга 2", 10, 10 });

            migrationBuilder.InsertData(
                table: "dataBook",
                columns: new[] { "Id", "AuthorId", "AuthorName", "NameBook", "RealQuantity", "TotalQuantity" },
                values: new object[] { 3, 3, "Автор 3", "Книга 3", 5, 5 });

            migrationBuilder.InsertData(
                table: "dataOrder",
                columns: new[] { "Id", "BookId", "BookName", "DateOrder", "RegUserName", "RegistrationId" },
                values: new object[] { 1, 1, "Книга 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", 1 });

            migrationBuilder.InsertData(
                table: "dataOrder",
                columns: new[] { "Id", "BookId", "BookName", "DateOrder", "RegUserName", "RegistrationId" },
                values: new object[] { 2, 2, "Книга 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дмитрий", 2 });

            migrationBuilder.InsertData(
                table: "dataOrder",
                columns: new[] { "Id", "BookId", "BookName", "DateOrder", "RegUserName", "RegistrationId" },
                values: new object[] { 3, 3, "Книга 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Александр", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_dataBook_AuthorId",
                table: "dataBook",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_dataOrder_BookId",
                table: "dataOrder",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_dataOrder_RegistrationId",
                table: "dataOrder",
                column: "RegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataOrder");

            migrationBuilder.DropTable(
                name: "dataBook");

            migrationBuilder.DropTable(
                name: "dataRegUser");

            migrationBuilder.DropTable(
                name: "dataAuthor");
        }
    }
}
