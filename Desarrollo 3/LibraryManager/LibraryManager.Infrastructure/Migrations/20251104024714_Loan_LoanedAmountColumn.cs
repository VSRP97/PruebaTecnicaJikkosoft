using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Loan_LoanedAmountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "loaned_amount",
                table: "loan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "loaned_amount",
                table: "loan");
        }
    }
}
