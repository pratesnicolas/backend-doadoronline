﻿// <auto-generated />
using System;
using DoadorOnline.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoadorOnline.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoadorOnline.Domain.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("District")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DonatorId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("DoadorOnline.Domain.Campaign", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("CampaignImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("DonationPlace")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DonatorId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DoneeBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoneeBloodType")
                        .HasColumnType("int");

                    b.Property<string>("DoneeName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DoneeRhFactor")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("Campaigns", (string)null);
                });

            modelBuilder.Entity("DoadorOnline.Domain.Donation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonationPlace")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DonationType")
                        .HasColumnType("int");

                    b.Property<string>("DonatorId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PointsEarned")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("Donations", (string)null);
                });

            modelBuilder.Entity("DoadorOnline.Domain.DonationIntention", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DonationType")
                        .HasColumnType("int");

                    b.Property<string>("DonatorId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("DonationIntentions", (string)null);
                });

            modelBuilder.Entity("DoadorOnline.Domain.Donator", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cpf")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RhesusFactor")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DoadorOnline.Domain.PartnerSale", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DonatorId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("SaleName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("PartnerSales", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "Administrator",
                            ConcurrencyStamp = "f23ff1e4-cfb7-4a29-a917-8f121985cc2e",
                            Name = "Administrator",
                            NormalizedName = "Administrator"
                        },
                        new
                        {
                            Id = "Hospital",
                            ConcurrencyStamp = "85466e90-164d-41e5-a9aa-bd0d7e3f8343",
                            Name = "Hospital",
                            NormalizedName = "Hospital"
                        },
                        new
                        {
                            Id = "Donee",
                            ConcurrencyStamp = "801d704e-d6e3-4452-937f-4e41a7d94c0a",
                            Name = "Donee",
                            NormalizedName = "Donee"
                        },
                        new
                        {
                            Id = "Donator",
                            ConcurrencyStamp = "33bd2861-d56c-4616-a3ef-aa0338872fe2",
                            Name = "Donator",
                            NormalizedName = "Donator"
                        },
                        new
                        {
                            Id = "Partner",
                            ConcurrencyStamp = "4bda7bbc-a7de-4b9f-a26b-5082e905eea3",
                            Name = "Partner",
                            NormalizedName = "Partner"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Value")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DoadorOnline.Domain.Address", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("DonatorId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoadorOnline.Domain.Campaign", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", "User")
                        .WithMany("Campaigns")
                        .HasForeignKey("DonatorId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoadorOnline.Domain.Donation", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", "User")
                        .WithMany("Donations")
                        .HasForeignKey("DonatorId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoadorOnline.Domain.DonationIntention", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", null)
                        .WithMany("DonationIntentions")
                        .HasForeignKey("DonatorId");
                });

            modelBuilder.Entity("DoadorOnline.Domain.PartnerSale", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", "User")
                        .WithMany("PartnerSales")
                        .HasForeignKey("DonatorId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoadorOnline.Domain.Donator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DoadorOnline.Domain.Donator", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoadorOnline.Domain.Donator", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Campaigns");

                    b.Navigation("DonationIntentions");

                    b.Navigation("Donations");

                    b.Navigation("PartnerSales");
                });
#pragma warning restore 612, 618
        }
    }
}
