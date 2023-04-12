using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class updatekorisnickinalogremoveemailfromimamandslikaaddpaging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Imam");

            migrationBuilder.DropColumn(
                name: "slika_imama_bytes",
                table: "Imam");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "KorisnickiNalog");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Imam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "slika_imama_bytes",
                table: "Imam",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
