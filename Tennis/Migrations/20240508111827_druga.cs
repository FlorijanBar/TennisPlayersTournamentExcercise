using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tennis.Migrations
{
    /// <inheritdoc />
    public partial class druga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Coachs_CoachId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Coachs_CoachId",
                table: "Players",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Coachs_CoachId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Coachs_CoachId",
                table: "Players",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
