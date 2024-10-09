﻿// <auto-generated />
using System;
using BpMeasurementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BpMeasurementApp.Migrations
{
    [DbContext(typeof(BpMeasurementDbContext))]
    [Migration("20241005033439_AddPosition")]
    partial class AddPosition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BpMeasurementApp.Entities.BpMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Diastolic")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeasurementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PositionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Systolic")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionID");

                    b.ToTable("Measurements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Diastolic = 80,
                            MeasurementDate = new DateTime(2024, 10, 4, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2142),
                            PositionID = "S",
                            Systolic = 120
                        },
                        new
                        {
                            Id = 2,
                            Diastolic = 85,
                            MeasurementDate = new DateTime(2024, 10, 3, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2187),
                            PositionID = "L",
                            Systolic = 130
                        },
                        new
                        {
                            Id = 3,
                            Diastolic = 90,
                            MeasurementDate = new DateTime(2024, 10, 2, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2191),
                            PositionID = "ST",
                            Systolic = 140
                        });
                });

            modelBuilder.Entity("BpMeasurementApp.Entities.Position", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            ID = "S",
                            Name = "Sitting"
                        },
                        new
                        {
                            ID = "L",
                            Name = "Lying down"
                        },
                        new
                        {
                            ID = "ST",
                            Name = "Standing"
                        });
                });

            modelBuilder.Entity("BpMeasurementApp.Entities.BpMeasurement", b =>
                {
                    b.HasOne("BpMeasurementApp.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
