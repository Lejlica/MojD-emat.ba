using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class twof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "twoFcode",
                table: "AutentifikacijaToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "twoFcodeJelOtkljucan",
                table: "AutentifikacijaToken",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "twoFcode",
                table: "AutentifikacijaToken");

            migrationBuilder.DropColumn(
                name: "twoFcodeJelOtkljucan",
                table: "AutentifikacijaToken");
        }
    }
}
