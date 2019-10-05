using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveUserPositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPosition");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionId",
                table: "User",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PositionId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "UserPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false),
                    EntityStatus = table.Column<int>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPosition_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPosition_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPosition_PositionId",
                table: "UserPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosition_UserId",
                table: "UserPosition",
                column: "UserId");
        }
    }
}
