using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LibraryBookFKIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_library_book_library_id",
                table: "library_book");

            migrationBuilder.CreateIndex(
                name: "ix_library_book_library_id_book_id",
                table: "library_book",
                columns: new[] { "library_id", "book_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_library_book_library_id_book_id",
                table: "library_book");

            migrationBuilder.CreateIndex(
                name: "ix_library_book_library_id",
                table: "library_book",
                column: "library_id");
        }
    }
}
