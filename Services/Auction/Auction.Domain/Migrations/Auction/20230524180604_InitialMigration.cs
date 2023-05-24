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
                    AuctionStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionStatuses", x => x.AuctionStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Bidders",
                schema: "auction",
                columns: table => new
                {
                    BidderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.BidderId);
                    table.ForeignKey(
                        name: "FK_Bidders_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "auction",
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidStatuses",
                schema: "auction",
                columns: table => new
                {
                    BidStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidStatuses", x => x.BidStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                schema: "auction",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                    table.ForeignKey(
                        name: "FK_Sellers_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "auction",
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutchAuctions",
                schema: "auction",
                columns: table => new
                {
                    DutchAuctionId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_DutchAuctions", x => x.DutchAuctionId);
                    table.ForeignKey(
                        name: "FK_DutchAuctions_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalSchema: "auction",
                        principalTable: "Administrator",
                        principalColumn: "AdministratorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutchAuctions_AuctionStatuses_AuctionStatusId",
                        column: x => x.AuctionStatusId,
                        principalSchema: "auction",
                        principalTable: "AuctionStatuses",
                        principalColumn: "AuctionStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutchAuctions_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "auction",
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "auction",
                columns: table => new
                {
                    BidId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BidTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidStatusId = table.Column<int>(type: "int", nullable: false),
                    BidderId = table.Column<int>(type: "int", nullable: false),
                    DutchAuctionId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.BidId);
                    table.ForeignKey(
                        name: "FK_Bids_BidStatuses_BidStatusId",
                        column: x => x.BidStatusId,
                        principalSchema: "auction",
                        principalTable: "BidStatuses",
                        principalColumn: "BidStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Bidders_BidId",
                        column: x => x.BidId,
                        principalSchema: "auction",
                        principalTable: "Bidders",
                        principalColumn: "BidderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_DutchAuctions_DutchAuctionId",
                        column: x => x.DutchAuctionId,
                        principalSchema: "auction",
                        principalTable: "DutchAuctions",
                        principalColumn: "DutchAuctionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "auction",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_DutchAuctions_DutchAuctionId",
                        column: x => x.DutchAuctionId,
                        principalSchema: "auction",
                        principalTable: "DutchAuctions",
                        principalColumn: "DutchAuctionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "auction",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bids_BidId",
                        column: x => x.BidId,
                        principalSchema: "auction",
                        principalTable: "Bids",
                        principalColumn: "BidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bidders_AccountId",
                schema: "auction",
                table: "Bidders",
                column: "AccountId");

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
                column: "AccountId");
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
