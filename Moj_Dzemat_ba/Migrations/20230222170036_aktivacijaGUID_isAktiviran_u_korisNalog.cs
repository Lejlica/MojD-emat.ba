using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class aktivacijaGUIDisAktiviranukorisNalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aktivacijaGUID",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAktiviran",
                table: "KorisnickiNalog",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aktivacijaGUID",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "isAktiviran",
                table: "KorisnickiNalog");
        }
    }
}
