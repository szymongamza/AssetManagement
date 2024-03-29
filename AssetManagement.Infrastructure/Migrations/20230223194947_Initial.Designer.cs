﻿// <auto-generated />
using System;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetManagement.Infrastructure.Migrations
{
    [DbContext(typeof(AssetManagementContext))]
    [Migration("20230223194947_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("AssetManagement.Domain.Entities.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateTimeOfBuy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateTimeOfEndOfGuarantee")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateTimeOfNextMaintenance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ManufacturerSerialNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BuildingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Asset", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Assets")
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("AssetManagement.Domain.Entities.Room", "Room")
                        .WithMany("Assets")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Department", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Faculty", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Building", null)
                        .WithMany("Faculties")
                        .HasForeignKey("BuildingId");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Maintenance", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Asset", "Product")
                        .WithMany("Maintenances")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Room", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Asset", b =>
                {
                    b.Navigation("Maintenances");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Building", b =>
                {
                    b.Navigation("Faculties");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Faculty", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Manufacturer", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Room", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
