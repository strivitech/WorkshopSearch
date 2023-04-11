using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Database.Main.Migrations
{
    /// <inheritdoc />
    public partial class Add_Workshop_Rating_Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Workshops",
                type: "real",
                maxLength: 5,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                table: "Workshops",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                table: "Workshops");
        }
    }
}
