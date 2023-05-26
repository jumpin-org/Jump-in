using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JumpIn.Auction.Domain.Migrations.Auction
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auction");

            migrationBuilder.CreateTable(
                name: "AuctionStatuses",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bidders",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bidders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "admin",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidStatuses",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "admin",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutchAuctions",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StartPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Decrement = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionStatusId = table.Column<int>(type: "int", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutchAuctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DutchAuctions_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalSchema: "admin",
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutchAuctions_AuctionStatuses_AuctionStatusId",
                        column: x => x.AuctionStatusId,
                        principalSchema: "auction",
                        principalTable: "AuctionStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DutchAuctions_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "auction",
                        principalTable: "Sellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BidTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidStatusId = table.Column<int>(type: "int", nullable: false),
                    DutchAuctionId = table.Column<int>(type: "int", nullable: false),
                    BidderId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_BidStatuses_BidStatusId",
                        column: x => x.BidStatusId,
                        principalSchema: "auction",
                        principalTable: "BidStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bids_Bidders_BidderId",
                        column: x => x.BidderId,
                        principalSchema: "auction",
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_DutchAuctions_DutchAuctionId",
                        column: x => x.DutchAuctionId,
                        principalSchema: "auction",
                        principalTable: "DutchAuctions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThumbnailPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ThumbnailPhotoFileName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AdditionalDetail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DutchAuctionId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_DutchAuctions_DutchAuctionId",
                        column: x => x.DutchAuctionId,
                        principalSchema: "auction",
                        principalTable: "DutchAuctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProofOfPayment = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BidId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bids_BidId",
                        column: x => x.BidId,
                        principalSchema: "auction",
                        principalTable: "Bids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bidders_AccountId",
                schema: "auction",
                table: "Bidders",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidderId",
                schema: "auction",
                table: "Bids",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidStatusId",
                schema: "auction",
                table: "Bids",
                column: "BidStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_DutchAuctionId",
                schema: "auction",
                table: "Bids",
                column: "DutchAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_DutchAuctions_AdministratorId",
                schema: "auction",
                table: "DutchAuctions",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DutchAuctions_AuctionStatusId",
                schema: "auction",
                table: "DutchAuctions",
                column: "AuctionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DutchAuctions_SellerId",
                schema: "auction",
                table: "DutchAuctions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BidId",
                schema: "auction",
                table: "Payments",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DutchAuctionId",
                schema: "auction",
                table: "Products",
                column: "DutchAuctionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_AccountId",
                schema: "auction",
                table: "Sellers",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "BidStatuses",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "Bidders",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "DutchAuctions",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "AuctionStatuses",
                schema: "auction");

            migrationBuilder.DropTable(
                name: "Sellers",
                schema: "auction");
        }
    }
}
