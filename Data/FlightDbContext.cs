using FlightManagementCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightManagementCompany.Data
{
    public class FlightDbContext : DbContext
    {
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AircraftMaintenance> AircraftMaintenances { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightCrew> FlightCrews { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AEOLTE6;Initial Catalog=FlightMSDB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Airport Entity Configuration
            // AirportId Primary Key
            modelBuilder.Entity<Airport>()
                .HasKey(a => a.AirportID);
            // AirportId auto-increment
            modelBuilder.Entity<Airport>()
                .Property(a => a.AirportID)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for AirportId
            // IATA
            modelBuilder.Entity<Airport>()
                .Property(a => a.IATA)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnType("nvarchar(3)"); // string type with max length 3 for IATA code
            // Unique constraint on IATA
            modelBuilder.Entity<Airport>()
                .HasIndex(a => a.IATA)
                .IsUnique(); // Ensure IATA code is unique
            // Name
            modelBuilder.Entity<Airport>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)"); // string type with max length 100
            // City
            modelBuilder.Entity<Airport>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)"); // string type with max length 100
            // Country
            modelBuilder.Entity<Airport>()
                .Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)"); // string type with max length 100
            // TimeZone
            modelBuilder.Entity<Airport>()
                .Property(a => a.TimeZone)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50
            // Navigation properties
            // one to many relationship with Route
            // One airport can be the origin or destination of many routes
            modelBuilder.Entity<Airport>()
                .HasMany(a => a.OriginRoutes) // many origin routes
                .WithOne(r => r.OriginAirport) // one Route
                .HasForeignKey(r => r.OriginAirportId) // Foreign key in Route
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes
            modelBuilder.Entity<Airport>()
                .HasMany(a => a.DestinationRoutes) // many destination routes
                .WithOne(r => r.DestinationAirport) // one Route
                .HasForeignKey(r => r.DestinationAirportId) // Foreign key in Route
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            //-------------------------------
            // Route Entity Configuration
            // RouteId Primary Key
            modelBuilder.Entity<Route>()
                .HasKey(r => r.RouteId);
            // RouteId auto-increment
            modelBuilder.Entity<Route>()
                .Property(r => r.RouteId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for RouteId

            // DistanceKm is required
            modelBuilder.Entity<Route>()
                .Property(r => r.DistanceKm)
                .IsRequired()
                .HasColumnType("int"); // int type for DistanceKm
            // Navigation properties
            // one to many relationship with Flight
            // One route can have many flights

            modelBuilder.Entity<Route>()
                .HasMany(r => r.Flights) // many flights
                .WithOne(f => f.Route) // one Route
                .HasForeignKey(f => f.RouteId) // Foreign key in Flight
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with Airport
            modelBuilder.Entity<Route>()
                .HasOne(r => r.OriginAirport) // one origin airport
                .WithMany(a => a.OriginRoutes) // many origin routes in Airport
                .HasForeignKey(r => r.OriginAirportId) // Foreign key in Route
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            modelBuilder.Entity<Route>()
                .HasOne(r => r.DestinationAirport) //  one destination airport
                .WithMany(a => a.DestinationRoutes) // many destination routes in Airport
                .HasForeignKey(r => r.DestinationAirportId) // Foreign key in Route
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            //-------------------------------

            // Flight Entity Configuration
            // FlightId Primary Key
            modelBuilder.Entity<Flight>()
                .HasKey(f => f.FlightId);
            // FlightId auto-increment
            modelBuilder.Entity<Flight>()
                .Property(f => f.FlightId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for FlightId

            // FlightNumber is required
            modelBuilder.Entity<Flight>()
                .Property(f => f.FlightNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar(10)"); // string type with max length 10
            // Unique constraint on FlightNumber
            modelBuilder.Entity<Flight>()
                .HasIndex(f => f.FlightNumber)
                .IsUnique(); // Ensure FlightNumber is unique
            // DepartureUtc is required
            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureUtc)
                .IsRequired()
                .HasColumnType("datetime"); // DateTime type for DepartureUtc
            // Unique constraint on DepartureUtc 
            modelBuilder.Entity<Flight>()
                .HasIndex(f => f.DepartureUtc)
                .IsUnique(); // Ensure DepartureUtc is unique
            // ArrivalUtc is required
            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalUtc)
                .IsRequired()
                .HasColumnType("datetime"); // DateTime type for ArrivalUtc

            // Status is required
            modelBuilder.Entity<Flight>()
                .Property(f => f.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20

            // Navigation properties
            // one to many relationship with Ticket
            // One flight can have many tickets
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Tickets) // many tickets
                .WithOne(t => t.Flight) // one Flight
                .HasForeignKey(t => t.FlightId) // Foreign key in Ticket
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with FlightCrew
            // One flight can have many crew members
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.FlightCrew) // many crew members
                .WithOne(fc => fc.Flight) // one Flight
                .HasForeignKey(fc => fc.FlightId) // Foreign key in FlightCrew
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with Aircraft
            // One flight can be assigned to one aircraft
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Aircraft) // one Aircraft
                .WithMany(a => a.Flights) // many Flights in Aircraft
                .HasForeignKey(f => f.AircraftId) // Foreign key in Flight
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with Route
            // One flight can be assigned to one route
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Route) // one Route
                .WithMany(r => r.Flights) // many Flights in Route
                .HasForeignKey(f => f.RouteId) // Foreign key in Flight
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            //-------------------------------

            // Ticket Entity Configuration
            // TicketId Primary Key
            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.TicketId);
            // TicketId auto-increment
            modelBuilder.Entity<Ticket>()
                .Property(t => t.TicketId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for TicketId

            // SeatNumber is required
            modelBuilder.Entity<Ticket>()
                .Property(t => t.SeatNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar(10)"); // string type with max length 10

            // Fare is required
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Fare)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // decimal type for Fare with precision 18 and scale 2

            //CheckedIn is required
            modelBuilder.Entity<Ticket>()
                .Property(t => t.CheckedIn)
                .IsRequired()
                .HasColumnType("bit"); // boolean type for CheckedIn

            // Navigation properties
            // one to many relationship with Baggage
            // One ticket can have many baggage items
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Baggages) // many baggage items
                .WithOne(b => b.Ticket) // one Ticket
                .HasForeignKey(b => b.TicketId) // Foreign key in Baggage
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with Booking
            // One ticket can be associated with one booking
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Booking) // one Booking
                .WithMany(b => b.Tickets) // many Tickets in Booking
                .HasForeignKey(t => t.BookingId) // Foreign key in Ticket
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with Flight
            // One ticket can be associated with one flight
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Flight) // one Flight
                .WithMany(f => f.Tickets) // many Tickets in Flight
                .HasForeignKey(t => t.FlightId) // Foreign key in Ticket
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            //-------------------------------


            // Aircraft Entity Configuration
            // AircraftId Primary Key
            modelBuilder.Entity<Aircraft>()
                .HasKey(a => a.AircraftId);
            // AircraftId auto-increment
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.AircraftId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for AircraftId

            // TailNumber is required
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.TailNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("nvarchar(10)"); // string type with max length 10
            // Unique constraint on TailNumber
            modelBuilder.Entity<Aircraft>()
                .HasIndex(a => a.TailNumber)
                .IsUnique(); // Ensure TailNumber is unique
            // Model is required
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.Model)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50

            // Capacity is required
            modelBuilder.Entity<Aircraft>()
                .Property(a => a.Capacity)
                .IsRequired()
                .HasColumnType("int"); // int type for Capacity

            // Navigation properties
            // one to many relationship with Flight
            // One aircraft can have many flights
            modelBuilder.Entity<Aircraft>()
                .HasMany(a => a.Flights) // many flights
                .WithOne(f => f.Aircraft) // one Aircraft
                .HasForeignKey(f => f.AircraftId) // Foreign key in Flight
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // one to many relationship with AircraftMaintenance
            // One aircraft can have many maintenance records
            modelBuilder.Entity<Aircraft>()
                .HasMany(a => a.AircraftMaintenances) // many maintenance records
                .WithOne(am => am.Aircraft) // one Aircraft
                .HasForeignKey(am => am.AircraftId) // Foreign key in AircraftMaintenance
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            //-------------------------------


            // AircraftMaintenance Entity Configuration
            // AircraftMaintenanceId Primary Key
            modelBuilder.Entity<AircraftMaintenance>()
                .HasKey(am => am.MaintenanceId);
            // AircraftMaintenanceId auto-increment
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.MaintenanceId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for AircraftMaintenanceId
            // MaintenanceDate is required
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.MaintenanceDate)
                .IsRequired()
                .HasColumnType("datetime"); // DateTime type for MaintenanceDate


            // Type is required
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50

            // Notes is required
            modelBuilder.Entity<AircraftMaintenance>()
                .Property(am => am.Notes)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)"); // string type with max length 500

            // Navigation properties
            // one to many relationship with Aircraft
            // One aircraft maintenance record is associated with one aircraft
            modelBuilder.Entity<AircraftMaintenance>()
                .HasOne(am => am.Aircraft) // one Aircraft
                .WithMany(a => a.AircraftMaintenances) // many maintenance records in Aircraft
                .HasForeignKey(am => am.AircraftId) // Foreign key in AircraftMaintenance
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            //-------------------------------

            // Passenger Entity Configuration
            // PassengerId Primary Key
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.PassengerId);
            modelBuilder.Entity<Passenger>()
                .Property(p => p.PassengerId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for PassengerId

            // FullName is required
            modelBuilder.Entity<Passenger>()
                .Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)"); // string type with max length 100

            // PassportNo is required
            modelBuilder.Entity<Passenger>()
                .Property(p => p.PassportNo)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20
            // Unique constraint on PassportNo
            modelBuilder.Entity<Passenger>()
                .HasIndex(p => p.PassportNo)
                .IsUnique(); // Ensure PassportNo is unique
            // Nationality is required
            modelBuilder.Entity<Passenger>()
                .Property(p => p.Nationality)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50

            // DOB is required
            modelBuilder.Entity<Passenger>()
                .Property(p => p.DOB)
                .IsRequired()
                .HasColumnType("datetime"); // DateTime type for DOB

            // Navigation properties
            // one to many relationship with Booking
            // One passenger can have many bookings
            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Bookings) // many bookings
                .WithOne(b => b.Passenger) // one Passenger
                .HasForeignKey(b => b.PassengerId) // Foreign key in Booking
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes
           


            //-------------------------------

            // Booking Entity Configuration
            // BookingId Primary Key
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingId);
            // BookingId auto-increment
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for BookingId

            // BookingRef is required
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingRef)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20
            // Unique constraint on BookingRef
            modelBuilder.Entity<Booking>()
                .HasIndex(b => b.BookingRef)
                .IsUnique(); // Ensure BookingRef is unique
            // BookingDate is required
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate)
                .IsRequired()
                .HasColumnType("datetime"); // DateTime type for BookingDate

            // Status is required
            modelBuilder.Entity<Booking>()
                .Property(b => b.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20

            // Navigation properties
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Tickets) // many tickets
                .WithOne(t => t.Booking) // one Booking
                .HasForeignKey(t => t.BookingId) // Foreign key in Ticket
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Passenger) // one Passenger
                .WithMany(p => p.Bookings) // many Bookings in Passenger
                .HasForeignKey(b => b.PassengerId) // Foreign key in Booking
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes


            // ---------------------

            // CrewMember Entity Configuration
            // CrewMemberId Primary Key
            modelBuilder.Entity<CrewMember>()
                .HasKey(cm => cm.CrewId);
            // CrewMemberId auto-increment
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.CrewId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for CrewMemberId


            // FullName is required
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)"); // string type with max length 100

            // Role is required
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.Role)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50


            // LicenseNo is required
            modelBuilder.Entity<CrewMember>()
                .Property(cm => cm.LicenseNo)
                .IsRequired(false) // LicenseNo is optional/nullable
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20

            // Navigation properties
            // one to many relationship with FlightCrew
            // One crew member can be assigned to many flights
            modelBuilder.Entity<CrewMember>()
                .HasMany(cm => cm.FlightCrews) // many flight crews
                .WithOne(fc => fc.CrewMember) // one CrewMember
                .HasForeignKey(fc => fc.CrewId) // Foreign key in FlightCrew
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // ----------------

            // FlightCrew Entity Configuration
            // Composite Key for FlightId and CrewId
            modelBuilder.Entity<FlightCrew>()
                .HasKey(fc => new { fc.FlightId, fc.CrewId });
            // FlightId Foreign Key
            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.Flight) // one Flight
                .WithMany(f => f.FlightCrew) // many FlightCrews in Flight
                .HasForeignKey(fc => fc.FlightId) // Foreign key in FlightCrew
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // CrewId Foreign Key
            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.CrewMember) // one CrewMember
                .WithMany(cm => cm.FlightCrews) // many FlightCrews in CrewMember
                .HasForeignKey(fc => fc.CrewId) // Foreign key in FlightCrew
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes

            // RoleOnFlight is required
            modelBuilder.Entity<FlightCrew>()
                .Property(fc => fc.RoleOnFlight)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)"); // string type with max length 50

            //----------------

            // Baggage Entity Configuration
            // BaggageId Primary Key
            modelBuilder.Entity<Baggage>()
                .HasKey(b => b.BaggageId);
            // BaggageId auto-increment
            modelBuilder.Entity<Baggage>()
                .Property(b => b.BaggageId)
                .ValueGeneratedOnAdd() // Auto-increment primary key
                .HasColumnType("int"); // int type for BaggageId

            // WeightKg is required
            modelBuilder.Entity<Baggage>()
                .Property(b => b.WeightKg)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // decimal type for Weight with precision 18 and scale 2

            // TagNumber is required
            modelBuilder.Entity<Baggage>()
                .Property(b => b.TagNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)"); // string type with max length 20

            // Navigation properties
            // one to many relationship with Ticket
            // One baggage item is associated with one ticket
            modelBuilder.Entity<Baggage>()
                .HasOne(b => b.Ticket) // one Ticket
                .WithMany(t => t.Baggages) // many Baggages in Ticket
                .HasForeignKey(b => b.TicketId) // Foreign key in Baggage
                .OnDelete(DeleteBehavior.NoAction); // No action on delete to prevent cascading deletes




        }


    }
}
