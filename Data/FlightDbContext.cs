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

            modelBuilder.Entity<FlightCrew>()
                .HasKey(fc => new { fc.FlightId, fc.CrewMemberId });
            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.Flight)
                .WithMany(f => f.FlightCrews)
                .HasForeignKey(fc => fc.FlightId);
            modelBuilder.Entity<FlightCrew>()
                .HasOne(fc => fc.CrewMember)
                .WithMany(cm => cm.FlightCrews)
                .HasForeignKey(fc => fc.CrewMemberId);
            base.OnModelCreating(modelBuilder);

        }
    }
}
