using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeperateTimeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timeline",
                table: "User");

            migrationBuilder.CreateTable(
                name: "TimeLineEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityStatus = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLineEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLineEvent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeLineEvent_UserId",
                table: "TimeLineEvent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLineEvent");

            migrationBuilder.AddColumn<string>(
                name: "Timeline",
                table: "User",
                nullable: true);
        }
    }
}
