using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class FKimamuaktivnosttabelu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImamId",
                table: "Aktivnost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aktivnost_ImamId",
                table: "Aktivnost",
                column: "ImamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktivnost_Imam_ImamId",
                table: "Aktivnost",
                column: "ImamId",
                principalTable: "Imam",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktivnost_Imam_ImamId",
                table: "Aktivnost");

            migrationBuilder.DropIndex(
                name: "IX_Aktivnost_ImamId",
                table: "Aktivnost");

            migrationBuilder.DropColumn(
                name: "ImamId",
                table: "Aktivnost");
        }
    }
}
