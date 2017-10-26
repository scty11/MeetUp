﻿// <auto-generated />
using MeetUp.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MeetUp.Data.Migrations
{
    [DbContext(typeof(MeetUpContext))]
    partial class MeetUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MeetUp.Data.models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("MeetUpId");

                    b.Property<string>("Name");

                    b.Property<int?>("SeatId");

                    b.HasKey("Id");

                    b.HasIndex("MeetUpId");

                    b.HasIndex("SeatId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MeetUp.Data.models.MeetUpDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("MeetUps");
                });

            modelBuilder.Entity("MeetUp.Data.models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SeatNumber");

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("MeetUp.Data.models.Booking", b =>
                {
                    b.HasOne("MeetUp.Data.models.MeetUpDetail", "MeetUp")
                        .WithMany("Bookings")
                        .HasForeignKey("MeetUpId");

                    b.HasOne("MeetUp.Data.models.Seat", "Seat")
                        .WithMany("Bookings")
                        .HasForeignKey("SeatId");
                });
#pragma warning restore 612, 618
        }
    }
}
