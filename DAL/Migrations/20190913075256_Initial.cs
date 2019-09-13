using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    EntityStatus = table.Column<int>(),
                    CreatedTime = table.Column<DateTimeOffset>(),
                    UpdatedTime = table.Column<DateTimeOffset>(),
                    Name = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    EntityStatus = table.Column<int>(),
                    CreatedTime = table.Column<DateTimeOffset>(),
                    UpdatedTime = table.Column<DateTimeOffset>(),
                    Email = table.Column<string>(),
                    PasswordSalt = table.Column<byte[]>(),
                    PasswordHash = table.Column<byte[]>(),
                    DisplayName = table.Column<string>(),
                    AvatarUrl = table.Column<string>(nullable: true),
                    AllowTokensSince = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    EntityStatus = table.Column<int>(),
                    CreatedTime = table.Column<DateTimeOffset>(),
                    UpdatedTime = table.Column<DateTimeOffset>(),
                    UserId = table.Column<Guid>(),
                    RoleId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
