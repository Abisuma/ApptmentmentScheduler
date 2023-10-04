﻿// <auto-generated />
using System;
using ApptmentmentScheduler.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApptmentmentScheduler.DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230822155933_longadded")]
    partial class longadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("ApptmentmentScheduler.Models.Models.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateTime = new DateTime(2023, 8, 22, 16, 59, 33, 107, DateTimeKind.Local).AddTicks(25),
                            Description = "Meet with the Marketing team",
                            Name = "Abu Ghalib"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}