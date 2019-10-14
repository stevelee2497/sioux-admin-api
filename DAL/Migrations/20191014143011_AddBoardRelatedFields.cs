using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddBoardRelatedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhaseOrder",
                table: "Phase",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberType",
                table: "BoardUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhaseOrder",
                table: "Board",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhaseOrder",
                table: "Phase");

            migrationBuilder.DropColumn(
                name: "MemberType",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "PhaseOrder",
                table: "Board");
        }
    }
}
