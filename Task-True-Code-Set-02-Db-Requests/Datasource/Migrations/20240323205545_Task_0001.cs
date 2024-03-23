using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datasource.Migrations
{
    /// <inheritdoc />
    public partial class Task_0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dto");

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "dto",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dto",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TagToUser",
                schema: "dto",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagToUser", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TagToUser_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "dto",
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagToUser_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dto",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagToUser_TagId",
                schema: "dto",
                table: "TagToUser",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagToUser_UserId",
                schema: "dto",
                table: "TagToUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagToUser",
                schema: "dto");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "dto");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dto");
        }
    }
}
