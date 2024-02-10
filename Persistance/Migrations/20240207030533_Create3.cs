using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Create3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "degrees");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "degreeImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "degreeImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "degrees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
