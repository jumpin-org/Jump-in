using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JumpIn.Auction.Domain.Admin
{
    /// <inheritdoc />
    public partial class SeedFicaStatusData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "admin",
                table: "FicaStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "FICA verification process has not been initiated.", "Not Started" },
                    { 2, "FICA verification is in progress.", "In Progress" },
                    { 3, "FICA verification is pending and awaiting further action.", "Pending" },
                    { 4, "FICA verification has been completed and the individual or entity is verified.", "Verified" },
                    { 5, "FICA verification has been rejected due to failure to meet requirements or provide necessary documentation.", "Rejected" },
                    { 6, "FICA verification has expired and needs to be renewed.", "Expired" },
                    { 7, "FICA verification has been temporarily suspended for some reason.", "Suspended" },
                    { 8, "FICA verification process has been closed or terminated.", "Closed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "admin",
                table: "FicaStatuses",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
