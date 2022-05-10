﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220510095655_lastmig2")]
    partial class lastmig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Attendance", b =>
                {
                    b.Property<Guid>("AttendaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AttendanceTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CheckAttendance")
                        .HasColumnType("bit");

                    b.Property<Guid>("LabourId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AttendaceId");

                    b.HasIndex("LabourId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("DataAccess.Bid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BidNumber")
                        .HasColumnType("int");

                    b.Property<string>("BidRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("BidStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("BidType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bids");
                });

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

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Wages")
                        .HasColumnType("int");

                    b.Property<byte>("WagesType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("DataAccess.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdhaarNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DataAccess.GeneralRequestDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RecieverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecieverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("RecieverRole")
                        .HasColumnType("tinyint");

                    b.Property<string>("RecieverUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("SenderRole")
                        .HasColumnType("tinyint");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("generalRequestDB");
                });

            modelBuilder.Entity("DataAccess.Labour", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdhaarNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSkilled")
                        .HasColumnType("bit");

                    b.Property<string>("JobProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Wages")
                        .HasColumnType("int");

                    b.Property<byte>("WagesType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Labour");
                });

            modelBuilder.Entity("DataAccess.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdhaarNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ContractorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Wages")
                        .HasColumnType("int");

                    b.Property<byte>("WagesType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("DataAccess.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BidRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PartcipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BidId");

                    b.HasIndex("PartcipantId")
                        .IsUnique()
                        .HasFilter("[PartcipantId] IS NOT NULL");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("DataAccess.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SiteAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("DataAccess.SiteWorker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("WorkerId")
                        .IsUnique();

                    b.ToTable("SiteWorkers");
                });

            modelBuilder.Entity("DataAccess.Slider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("DataAccess.Testimonial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedbackMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("UserRole")
                        .HasColumnType("tinyint");

                    b.Property<byte>("status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Testimonials");
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

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87843532-0b93-492d-824b-68be17a82037"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTime(2022, 5, 10, 15, 26, 55, 430, DateTimeKind.Local).AddTicks(7257),
                            DOB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@yopmail.com",
                            Password = "Teq8e4GmOYAmNIrR0a/3/X6NjUSVHSbq4EaX3mSGZQ8=",
                            PhoneNo = "8825084050",
                            Salt = "CcFgiqGLSyHIihvUo0PVa0cUBRM=",
                            UpdatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "admin",
                            UserRole = (byte)1,
                            UserStatus = (byte)1
                        });
                });

            modelBuilder.Entity("DataAccess.Attendance", b =>
                {
                    b.HasOne("DataAccess.Labour", "Labour")
                        .WithMany()
                        .HasForeignKey("LabourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Labour");
                });

            modelBuilder.Entity("DataAccess.Bid", b =>
                {
                    b.HasOne("DataAccess.Customer", "Customer")
                        .WithMany("Bids")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
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

            modelBuilder.Entity("DataAccess.Labour", b =>
                {
                    b.HasOne("DataAccess.User", "User")
                        .WithOne("Labour")
                        .HasForeignKey("DataAccess.Labour", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Manager");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Manager", b =>
                {
                    b.HasOne("DataAccess.Contractor", "Contractor")
                        .WithMany("Managers")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccess.User", "User")
                        .WithOne("Manager")
                        .HasForeignKey("DataAccess.Manager", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contractor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Participant", b =>
                {
                    b.HasOne("DataAccess.Bid", "Bid")
                        .WithMany("Participants")
                        .HasForeignKey("BidId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.User", "User")
                        .WithOne("Participant")
                        .HasForeignKey("DataAccess.Participant", "PartcipantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Bid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.SiteWorker", b =>
                {
                    b.HasOne("DataAccess.Site", "Site")
                        .WithMany("SiteWorkers")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.User", "User")
                        .WithOne("SiteWorker")
                        .HasForeignKey("DataAccess.SiteWorker", "WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Site");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Bid", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("DataAccess.Contractor", b =>
                {
                    b.Navigation("Managers");
                });

            modelBuilder.Entity("DataAccess.Customer", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("DataAccess.Site", b =>
                {
                    b.Navigation("SiteWorkers");
                });

            modelBuilder.Entity("DataAccess.User", b =>
                {
                    b.Navigation("Contractor");

                    b.Navigation("Customer");

                    b.Navigation("Labour");

                    b.Navigation("Manager");

                    b.Navigation("Participant");

                    b.Navigation("SiteWorker");
                });
#pragma warning restore 612, 618
        }
    }
}
