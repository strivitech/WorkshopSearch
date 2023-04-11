using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Database.Main.Migrations
{
    /// <inheritdoc />
    public partial class Add_Workshops_Constrains_DaysCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Constrains_DaysCount",
                table: "Workshops",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Constrains_DaysCount",
                table: "Workshops");
        }
    }
}
