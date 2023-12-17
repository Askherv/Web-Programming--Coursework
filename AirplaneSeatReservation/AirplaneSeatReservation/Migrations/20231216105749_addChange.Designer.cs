﻿// <auto-generated />
using System;
using AirplaneSeatReservation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirplaneSeatReservation.Migrations
{
    [DbContext(typeof(FlightCS))]
    [Migration("20231216105749_addChange")]
    partial class addChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirplaneSeatReservation.Models.Admin", b =>
                {
                    b.Property<Guid>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Aircraft", b =>
                {
                    b.Property<Guid>("AircraftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AircraftModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AircraftSeats")
                        .HasColumnType("int");

                    b.HasKey("AircraftID");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Flight", b =>
                {
                    b.Property<Guid>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AircraftID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RouteID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FlightID");

                    b.HasIndex("AircraftID");

                    b.HasIndex("RouteID");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Passenger", b =>
                {
                    b.Property<Guid>("PassengerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PassengerBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassengerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PassengerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerID");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Reservation", b =>
                {
                    b.Property<Guid>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FlightID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PassengerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationID");

                    b.HasIndex("FlightID");

                    b.HasIndex("PassengerID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Route", b =>
                {
                    b.Property<Guid>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteID");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.UserAccount", b =>
                {
                    b.Property<Guid>("UserAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPassword")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserAccountID");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Flight", b =>
                {
                    b.HasOne("AirplaneSeatReservation.Models.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirplaneSeatReservation.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Reservation", b =>
                {
                    b.HasOne("AirplaneSeatReservation.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirplaneSeatReservation.Models.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });
#pragma warning restore 612, 618
        }
    }
}