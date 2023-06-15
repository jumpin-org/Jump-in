using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JumpIn.Auction.Domain.Admin
{
    /// <inheritdoc />
    public partial class FixDuplicateFicDetailId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FicaDetailId",
                schema: "admin",
                table: "FicaDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FicaDetailId",
                schema: "admin",
                table: "FicaDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
