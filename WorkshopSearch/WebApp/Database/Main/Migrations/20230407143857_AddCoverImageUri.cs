using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Database.Main.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverImageUri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUri",
                table: "Workshops",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUri",
                table: "Workshops");
        }
    }
}
