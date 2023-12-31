using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddcolumnportfolio1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Portfolios",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Portfolios",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Portfolios",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Portfolios",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Portfolios",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Portfolios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Portfolios");
        }
    }
}
