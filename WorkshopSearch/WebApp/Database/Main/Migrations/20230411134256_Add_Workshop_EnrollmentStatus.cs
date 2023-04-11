using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Database.Main.Migrations
{
    /// <inheritdoc />
    public partial class Add_Workshop_EnrollmentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "EnrollmentStatus",
                table: "Workshops",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentStatus",
                table: "Workshops");
        }
    }
}
