﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.ContactUs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("DataAccess.Contractor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("DataAccess.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DataAccess.Labour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdhaarNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSkilled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Labour");
                });

            modelBuilder.Entity("DataAccess.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("DataAccess.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LabourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Wages")
                        .HasColumnType("real");

                    b.Property<byte>("WagesType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("LabourId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DataAccess.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("UserRole")
                        .HasColumnType("tinyint");

                    b.Property<byte>("UserStatus")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("labourId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("labourId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87843532-0b93-492d-824b-68be17a82037"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTime(2022, 4, 14, 13, 1, 26, 913, DateTimeKind.Local).AddTicks(9833),
                            Email = "admin@yopmail.com",
                            Password = "SK7hGSJMFTUwdtAKHVTL+4tgfYjIw3+ZcRSIehtkg3o=",
                            PhoneNo = "8825084050",
                            Salt = "yq0HC5gYvyK5RDyo3ojva3AHBMI=",
                            UpdatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "admin",
                            UserRole = (byte)1,
                            UserStatus = (byte)1
                        });
                });

            modelBuilder.Entity("DataAccess.Contractor", b =>
                {
                    b.HasOne("DataAccess.User", "User")
                        .WithOne("Contractor")
                        .HasForeignKey("DataAccess.Contractor", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Customer", b =>
                {
                    b.HasOne("DataAccess.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("DataAccess.Customer", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Skill", b =>
                {
                    b.HasOne("DataAccess.Labour", "Labour")
                        .WithMany("Skills")
                        .HasForeignKey("LabourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Labour");
                });

            modelBuilder.Entity("DataAccess.User", b =>
                {
                    b.HasOne("DataAccess.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccess.Labour", "labour")
                        .WithMany()
                        .HasForeignKey("labourId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Manager");

                    b.Navigation("labour");
                });

            modelBuilder.Entity("DataAccess.Labour", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DataAccess.User", b =>
                {
                    b.Navigation("Contractor");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
