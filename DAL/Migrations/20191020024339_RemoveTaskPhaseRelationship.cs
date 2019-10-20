using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveTaskPhaseRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Phase_PhaseId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_PhaseId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "Task");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardId",
                table: "Task",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Task_BoardId",
                table: "Task",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Board_BoardId",
                table: "Task",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Board_BoardId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_BoardId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Task");

            migrationBuilder.AddColumn<Guid>(
                name: "PhaseId",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_PhaseId",
                table: "Task",
                column: "PhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Phase_PhaseId",
                table: "Task",
                column: "PhaseId",
                principalTable: "Phase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
