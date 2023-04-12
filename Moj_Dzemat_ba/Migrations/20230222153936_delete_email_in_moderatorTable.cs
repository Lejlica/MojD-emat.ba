using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojDzematba.Migrations
{
    /// <inheritdoc />
    public partial class deleteemailinmoderatorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Moderator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Moderator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
