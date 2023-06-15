﻿// <auto-generated />
using System;
using JumpIn.Auction.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JumpIn.Auction.Domain.Migrations.Admin
{
    [DbContext(typeof(AdminContext))]
    partial class AdminContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("admin")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts", "admin");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Administrators", "admin");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.FicaDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<int>("FicaDetailId")
                        .HasColumnType("int");

                    b.Property<int>("FicaStatusId")
                        .HasColumnType("int");

                    b.Property<byte[]>("IDDocument")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProofAddress")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("FicaStatusId");

                    b.ToTable("FicaDetails", "admin");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.FicaStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("FicaStatuses", "admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "FICA verification process has not been initiated.",
                            Name = "Not Started"
                        },
                        new
                        {
                            Id = 2,
                            Description = "FICA verification is in progress.",
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Description = "FICA verification is pending and awaiting further action.",
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 4,
                            Description = "FICA verification has been completed and the individual or entity is verified.",
                            Name = "Verified"
                        },
                        new
                        {
                            Id = 5,
                            Description = "FICA verification has been rejected due to failure to meet requirements or provide necessary documentation.",
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 6,
                            Description = "FICA verification has expired and needs to be renewed.",
                            Name = "Expired"
                        },
                        new
                        {
                            Id = 7,
                            Description = "FICA verification has been temporarily suspended for some reason.",
                            Name = "Suspended"
                        },
                        new
                        {
                            Id = 8,
                            Description = "FICA verification process has been closed or terminated.",
                            Name = "Closed"
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.ToTable("Users", "admin");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.AuctionStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("AuctionStatus", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

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

                    b.HasKey("Id");

                    b.HasIndex("BidStatusId");

                    b.HasIndex("BidderId");

                    b.HasIndex("DutchAuctionId");

                    b.ToTable("Bid", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.BidStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("BidStatus", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bidder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Bidder", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.DutchAuction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<int>("AuctionStatusId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Decrement")
                        .HasColumnType("decimal(18,2)");

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
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("AuctionStatusId");

                    b.HasIndex("SellerId");

                    b.ToTable("DutchAuction", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

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

                    b.HasKey("Id");

                    b.HasIndex("BidId");

                    b.ToTable("Payment", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("decimal(18,2)");

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
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DutchAuctionId")
                        .IsUnique();

                    b.ToTable("Product", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Seller", "admin", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
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
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("FicaStatus");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Bid", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.BidStatus", "BidStatus")
                        .WithMany("Bids")
                        .HasForeignKey("BidStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.Bidder", "Bidder")
                        .WithMany("Bids")
                        .HasForeignKey("BidderId")
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
                        .WithOne("Bidder")
                        .HasForeignKey("JumpIn.Auction.Domain.Models.Auction.Bidder", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.DutchAuction", b =>
                {
                    b.HasOne("JumpIn.Auction.Domain.Models.Admin.Administrator", "Administrator")
                        .WithMany("DutchAuctions")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.AuctionStatus", "AuctionStatus")
                        .WithMany("DutchAuctions")
                        .HasForeignKey("AuctionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JumpIn.Auction.Domain.Models.Auction.Seller", "Seller")
                        .WithMany("DutchAuctions")
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
                        .WithOne("Seller")
                        .HasForeignKey("JumpIn.Auction.Domain.Models.Auction.Seller", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Account", b =>
                {
                    b.Navigation("Bidder")
                        .IsRequired();

                    b.Navigation("FicaDetail")
                        .IsRequired();

                    b.Navigation("Seller")
                        .IsRequired();
                });

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Admin.Administrator", b =>
                {
                    b.Navigation("DutchAuctions");
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

            modelBuilder.Entity("JumpIn.Auction.Domain.Models.Auction.Seller", b =>
                {
                    b.Navigation("DutchAuctions");
                });
#pragma warning restore 612, 618
        }
    }
}
