using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace showcaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class ghjkjfcghbj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ownerRoom",
                table: "users",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ownerRoom",
                table: "users");
        }
    }
}
