using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace showcaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class ghjkjfcghbjjj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ownerRoom",
                table: "users",
                newName: "OwnerRoom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerRoom",
                table: "users",
                newName: "ownerRoom");
        }
    }
}
