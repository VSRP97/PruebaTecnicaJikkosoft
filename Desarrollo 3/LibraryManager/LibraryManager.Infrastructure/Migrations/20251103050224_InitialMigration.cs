using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    publication_year = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "library",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_library", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    second_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    second_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "library_book",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    library_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total_copies = table.Column<int>(type: "int", nullable: false),
                    available_copies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_library_book", x => x.id);
                    table.ForeignKey(
                        name: "fk_library_book_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_library_book_library_library_id",
                        column: x => x.library_id,
                        principalTable: "library",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "library_member",
                columns: table => new
                {
                    libraries_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    members_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_library_member", x => new { x.libraries_id, x.members_id });
                    table.ForeignKey(
                        name: "fk_library_member_library_libraries_id",
                        column: x => x.libraries_id,
                        principalTable: "library",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_library_member_member_members_id",
                        column: x => x.members_id,
                        principalTable: "member",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    library_book_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    member_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expected_return_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_loan", x => x.id);
                    table.ForeignKey(
                        name: "fk_loan_library_book_library_book_id",
                        column: x => x.library_book_id,
                        principalTable: "library_book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_loan_member_member_id",
                        column: x => x.member_id,
                        principalTable: "member",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_book_isbn",
                table: "book",
                column: "isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_library_book_book_id",
                table: "library_book",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_library_book_library_id",
                table: "library_book",
                column: "library_id");

            migrationBuilder.CreateIndex(
                name: "ix_library_member_members_id",
                table: "library_member",
                column: "members_id");

            migrationBuilder.CreateIndex(
                name: "ix_loan_library_book_id",
                table: "loan",
                column: "library_book_id");

            migrationBuilder.CreateIndex(
                name: "ix_loan_member_id",
                table: "loan",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "library_member");

            migrationBuilder.DropTable(
                name: "loan");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "library_book");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "library");
        }
    }
}
