using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace showcaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class ghjkjfcghbjjjj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerRoom",
                table: "users",
                newName: "Owner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "users",
                newName: "OwnerRoom");
        }
    }
}
