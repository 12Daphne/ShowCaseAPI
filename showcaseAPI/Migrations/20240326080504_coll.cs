using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace showcaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class coll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "players",
                table: "rooms",
                newName: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Players",
                table: "rooms",
                newName: "players");
        }
    }
}
