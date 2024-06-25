using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace showcaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class colli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Players",
                table: "rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Players",
                table: "rooms",
                type: "TEXT",
                nullable: true);
        }
    }
}
