using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JumpIn.Auction.Domain.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateAuctionAndAddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndTime",
                schema: "auction",
                table: "DutchAuctions",
                newName: "StartDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                schema: "auction",
                table: "DutchAuctions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WinningBidId",
                schema: "auction",
                table: "DutchAuctions",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "auction",
                table: "AuctionStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "New", "New" },
                    { 2, "Active", "Active" },
                    { 3, "Started", "Started" },
                    { 4, "In Progress", "In Progress" },
                    { 5, "Ended", "Ended" },
                    { 6, "Closed", "Closed" },
                    { 7, "Deactivated", "Deactivated" }
                });

            migrationBuilder.InsertData(
                schema: "auction",
                table: "BidStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "New", "New" },
                    { 2, "Placed", "Placed" },
                    { 3, "Active", "Active" },
                    { 4, "Highest", "Highest" },
                    { 5, "Lowest", "Lowest" },
                    { 6, "Revoked", "Revoked" },
                    { 7, "Invalid", "Invalid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "AuctionStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "auction",
                table: "BidStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                schema: "auction",
                table: "DutchAuctions");

            migrationBuilder.DropColumn(
                name: "WinningBidId",
                schema: "auction",
                table: "DutchAuctions");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                schema: "auction",
                table: "DutchAuctions",
                newName: "EndTime");
        }
    }
}
