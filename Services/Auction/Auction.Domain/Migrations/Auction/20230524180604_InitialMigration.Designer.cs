﻿// <auto-generated />
using System;
using JumpIn.Auction.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JumpIn.Auction.Domain.Migrations.Auction
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20230524180604_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("auction")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account", "auction", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdministratorId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Administrator", "auction", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.FicaDetail", b =>
                {
                    b.Property<int>("FicaDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FicaDetailId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("FicaStatusId")
                        .HasColumnType("int");

                    b.Property<byte[]>("IDDocument")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProofAddress")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FicaDetailId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("FicaStatusId");

                    b.ToTable("FicaDetail", "auction", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.FicaStatus", b =>
                {
                    b.Property<int>("FicaStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("FicaStatusId");

                    b.ToTable("FicaStatus", "auction", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueEID")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("UserId");

                    b.ToTable("User", "auction", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.AuctionStatus", b =>
                {
                    b.Property<int>("AuctionStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("AuctionStatusId");

                    b.ToTable("AuctionStatuses", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bid", b =>
                {
                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("BidStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BidTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BidderId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("DutchAuctionId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BidId");

                    b.HasIndex("BidStatusId");

                    b.HasIndex("DutchAuctionId");

                    b.ToTable("Bids", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.BidStatus", b =>
                {
                    b.Property<int>("BidStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("BidStatusId");

                    b.ToTable("BidStatuses", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bidder", b =>
                {
                    b.Property<int>("BidderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidderId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.HasKey("BidderId");

                    b.HasIndex("AccountId");

                    b.ToTable("Bidders", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.DutchAuction", b =>
                {
                    b.Property<int>("DutchAuctionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DutchAuctionId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<int>("AuctionStatusId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Decrement")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<decimal>("StartPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("DutchAuctionId");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("AuctionStatusId");

                    b.HasIndex("SellerId");

                    b.ToTable("DutchAuctions", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("BidId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ProofOfPayment")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("BidId");

                    b.ToTable("Payments", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("AdditionalDetail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DiscontinuedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DutchAuctionId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ProductNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<byte[]>("ThumbnailPhoto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ThumbnailPhotoFileName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ProductId");

                    b.HasIndex("DutchAuctionId")
                        .IsUnique();

                    b.ToTable("Products", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SellerId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.HasKey("SellerId");

                    b.HasIndex("AccountId");

                    b.ToTable("Sellers", "auction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Account", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("JumpIn.Auction.Domain.Models.Admin.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Administrator", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.User", "User")
                        .WithOne("Administrator")
                        .HasForeignKey("JumpIn.Auction.Domain.Models.Admin.Administrator", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.FicaDetail", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.Account", "Account")
                        .WithOne("FicaDetail")
                        .HasForeignKey("JumpIn.Auction.Domain.Models.Admin.FicaDetail", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.FicaStatus", "FicaStatus")
                        .WithMany("FicaDetails")
                        .HasForeignKey("FicaStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("FicaStatus");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bid", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.Bidder", "Bidder")
                        .WithMany("Bids")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.BidStatus", "BidStatus")
                        .WithMany("Bids")
                        .HasForeignKey("BidStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.DutchAuction", "DutchAuction")
                        .WithMany("Bids")
                        .HasForeignKey("DutchAuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BidStatus");

                    b.Navigation("Bidder");

                    b.Navigation("DutchAuction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bidder", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.Account", "Account")
                        .WithMany("Bidders")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.DutchAuction", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.AuctionStatus", "AuctionStatus")
                        .WithMany("DutchAuctions")
                        .HasForeignKey("AuctionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("AuctionStatus");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Payment", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.Bid", "Bid")
                        .WithMany("Payments")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bid");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Product", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.DutchAuction", "DutchAuction")
                        .WithOne("Product")
                        .HasForeignKey("JumpIn.Auction.Domain.Models.Auction.Product", "DutchAuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DutchAuction");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Seller", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.Account", "Account")
                        .WithMany("Sellers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Account", b =>
                {
                    b.Navigation("Bidders");

                    b.Navigation("FicaDetail")
                        .IsRequired();

                    b.Navigation("Sellers");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.FicaStatus", b =>
                {
                    b.Navigation("FicaDetails");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Administrator")
                        .IsRequired();
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.AuctionStatus", b =>
                {
                    b.Navigation("DutchAuctions");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bid", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.BidStatus", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bidder", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.DutchAuction", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
