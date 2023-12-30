﻿// <auto-generated />
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
    [Migration("20231230144709_asdfghjk")]
    partial class asdfghjk
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
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Aircraft", b =>
                {
                    b.Property<int>("AircraftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AircraftID"));

                    b.Property<string>("AircraftModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AircraftSeats")
                        .HasColumnType("int");

                    b.HasKey("AircraftID");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightID"));

                    b.Property<int>("AircraftID")
                        .HasColumnType("int");

                    b.Property<int>("ItineraryID")
                        .HasColumnType("int");

                    b.HasKey("FlightID");

                    b.HasIndex("AircraftID");

                    b.HasIndex("ItineraryID");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Itinerary", b =>
                {
                    b.Property<int>("ItineraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItineraryID"));

                    b.Property<string>("ArrivalAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItineraryID");

                    b.ToTable("Itinerary");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerBirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerPassportNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("AirplaneSeatReservation.Models.UserAccount", b =>
                {
                    b.Property<int>("UserAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccountID"));

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

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasOne("AirplaneSeatReservation.Models.Itinerary", "Itinerary")
                        .WithMany()
                        .HasForeignKey("ItineraryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Itinerary");
                });
#pragma warning restore 612, 618
        }
    }
}
