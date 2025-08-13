using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Service
{
    public class FlightService
    {
        // Connecting the FlightService to the FlightRepository
        private readonly IFlightRepository _flightRepository;
        private readonly IAircraftMaintenanceRepository _aircraftMaintenanceRepository;
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly ICrewMemberRepository _crewMemberRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IBaggageRepository _baggageRepository;
        private readonly ITicketRepository _ticketRepository;
        
        public FlightService(FlightDbContext context) // Constructor injection for dependency
        {
            _flightRepository = new FlightRepository(context); // Initialize the repository with the context
          
        }

        // Create sample data
        public void CreateSampleData()
        {
            //// Airports (10)
            //modelBuilder.Entity<Airport>().HasData(
            //    new Airport { IATA = "JFK", Name = "John F. Kennedy", City = "New York", Country = "USA", TimeZone = "America/New_York" },
            //    new Airport { IATA = "LHR", Name = "Heathrow", City = "London", Country = "UK", TimeZone = "Europe/London" },
            //    new Airport { IATA = "MCT", Name = "Muscat International", City = "Muscat", Country = "Oman", TimeZone = "Asia/Muscat" },
            //    new Airport { IATA = "DXB", Name = "Dubai Intl", City = "Dubai", Country = "UAE", TimeZone = "Asia/Dubai" },
            //    new Airport { IATA = "SIN", Name = "Changi", City = "Singapore", Country = "Singapore", TimeZone = "Asia/Singapore" },
            //    new Airport { IATA = "LAX", Name = "Los Angeles Intl", City = "Los Angeles", Country = "USA", TimeZone = "America/Los_Angeles" },
            //    new Airport { IATA = "CDG", Name = "Charles de Gaulle", City = "Paris", Country = "France", TimeZone = "Europe/Paris" },
            //    new Airport { IATA = "FRA", Name = "Frankfurt", City = "Frankfurt", Country = "Germany", TimeZone = "Europe/Berlin" },
            //    new Airport { IATA = "BOM", Name = "Chhatrapati Shivaji", City = "Mumbai", Country = "India", TimeZone = "Asia/Kolkata" },
            //    new Airport { IATA = "SYD", Name = "Sydney Kingsford Smith", City = "Sydney", Country = "Australia", TimeZone = "Australia/Sydney" }
            //);

            //// Aircrafts (10)
            //modelBuilder.Entity<Aircraft>().HasData(
            //    new Aircraft { Model = "Boeing 777", Capacity = 396 },
            //    new Aircraft { Model = "Airbus A380", Capacity = 555 },
            //    new Aircraft { Model = "Boeing 737", Capacity = 189 },
            //    new Aircraft { Model = "Airbus A320", Capacity = 180 },
            //    new Aircraft { Model = "Boeing 787", Capacity = 242 },
            //    new Aircraft { Model = "Airbus A350", Capacity = 440 },
            //    new Aircraft { Model = "Boeing 747", Capacity = 660 },
            //    new Aircraft { Model = "Airbus A330", Capacity = 277 },
            //    new Aircraft { Model = "Boeing 767", Capacity = 216 },
            //    new Aircraft { Model = "Airbus A220", Capacity = 120 }
            //);

            //// Crew Members (20)
            //modelBuilder.Entity<Aircraft>().HasData(
            //    new Aircraft { TailNumber = "N12345", Model = "Boeing 777", Capacity = 396 },
            //    new Aircraft { TailNumber = "N67890", Model = "Airbus A380", Capacity = 555 },
            //    new Aircraft { TailNumber = "N54321", Model = "Boeing 737", Capacity = 189 },
            //    new Aircraft { TailNumber = "N09876", Model = "Airbus A320", Capacity = 180 },
            //    new Aircraft { TailNumber = "N11223", Model = "Boeing 787", Capacity = 242 },
            //    new Aircraft { TailNumber = "N44556", Model = "Airbus A350", Capacity = 440 },
            //    new Aircraft { TailNumber = "N77889", Model = "Boeing 747", Capacity = 660 },
            //    new Aircraft { TailNumber = "N99001", Model = "Airbus A330", Capacity = 277 },
            //    new Aircraft { TailNumber = "N22334", Model = "Boeing 767", Capacity = 216 },
            //    new Aircraft { TailNumber = "N55667", Model = "Airbus A220", Capacity = 120 },
            //    new Aircraft { TailNumber = "N88990", Model = "Boeing 737 MAX", Capacity = 210 },
            //    new Aircraft { TailNumber = "N11234", Model = "Airbus A321", Capacity = 220 },
            //    new Aircraft { TailNumber = "N44567", Model = "Boeing 757", Capacity = 200 },
            //    new Aircraft { TailNumber = "N77890", Model = "Airbus A319", Capacity = 150 },
            //    new Aircraft { TailNumber = "N99012", Model = "Boeing 767-300", Capacity = 218 },
            //    new Aircraft { TailNumber = "N22345", Model = "Airbus A310", Capacity = 280 },
            //    new Aircraft { TailNumber = "N55678", Model = "Boeing 787-9", Capacity = 296 },
            //    new Aircraft { TailNumber = "N88901", Model = "Airbus A350-900", Capacity = 440 },
            //    new Aircraft { TailNumber = "N11256", Model = "Boeing 777-300ER", Capacity = 550 },
            //    new Aircraft { TailNumber = "N44589", Model = "Airbus A330-300", Capacity = 277 }
            //);



            //// Flights(30)
            //modelBuilder.Entity<Flight>().HasData(
            //    new Flight { FlightNumber = "AA100", DepartureUtc = new DateTime(2025, 8, 21, 9, 0, 0), ArrivalUtc = new DateTime(2025, 8, 21, 12, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 1, RouteId = 2 },
            //    new Flight { FlightNumber = "BA200", DepartureUtc = new DateTime(2025, 8, 22, 10, 0, 0), ArrivalUtc = new DateTime(2025, 8, 22, 13, 0, 0), Status = FlightStatus.InFlight, AircraftId = 2, RouteId = 3 },
            //    new Flight { FlightNumber = "CA300", DepartureUtc = new DateTime(2025, 8, 23, 11, 0, 0), ArrivalUtc = new DateTime(2025, 8, 23, 14, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 3, RouteId = 4 },
            //    new Flight { FlightNumber = "DA400", DepartureUtc = new DateTime(2025, 8, 24, 12, 0, 0), ArrivalUtc = new DateTime(2025, 8, 24, 15, 0, 0), Status = FlightStatus.Landed, AircraftId = 4, RouteId = 5 },
            //    new Flight { FlightNumber = "EA500", DepartureUtc = new DateTime(2025, 8, 25, 13, 0, 0), ArrivalUtc = new DateTime(2025, 8, 25, 16, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 5, RouteId = 6 },
            //    new Flight { FlightNumber = "FA600", DepartureUtc = new DateTime(2025, 8, 26, 14, 0, 0), ArrivalUtc = new DateTime(2025, 8, 26, 17, 0, 0), Status = FlightStatus.InFlight, AircraftId = 6, RouteId = 7 },
            //    new Flight { FlightNumber = "GA700", DepartureUtc = new DateTime(2025, 8, 27, 15, 0, 0), ArrivalUtc = new DateTime(2025, 8, 27, 18, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
            //    new Flight { FlightNumber = "HA800", DepartureUtc = new DateTime(2025, 8, 28, 16, 0, 0), ArrivalUtc = new DateTime(2025, 8, 28, 19, 0, 0), Status = FlightStatus.Landed, AircraftId = 8, RouteId = 9 },
            //    new Flight { FlightNumber = "IA900", DepartureUtc = new DateTime(2025, 8, 29, 17, 0, 0), ArrivalUtc = new DateTime(2025, 8, 29, 20, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
            //    new Flight { FlightNumber = "JA1000", DepartureUtc = new DateTime(2025, 8, 30, 18, 0, 0), ArrivalUtc = new DateTime(2025, 8, 30, 21, 0, 0), Status = FlightStatus.InFlight, AircraftId = 10, RouteId = 1 },
            //    new Flight { FlightNumber = "KA1100", DepartureUtc = new DateTime(2025, 8, 31, 19, 0, 0), ArrivalUtc = new DateTime(2025, 8, 31, 22, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 1, RouteId = 2 },
            //    new Flight { FlightNumber = "LA1200", DepartureUtc = new DateTime(2025, 9, 1, 20, 0, 0), ArrivalUtc = new DateTime(2025, 9, 1, 23, 0, 0), Status = FlightStatus.Landed, AircraftId = 2, RouteId = 3 },
            //    new Flight { FlightNumber = "MA1300", DepartureUtc = new DateTime(2025, 9, 2, 21, 0, 0), ArrivalUtc = new DateTime(2025, 9, 2, 0, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 3, RouteId = 4 },
            //    new Flight { FlightNumber = "NA1400", DepartureUtc = new DateTime(2025, 9, 3, 22, 0, 0), ArrivalUtc = new DateTime(2025, 9, 3, 1, 0, 0), Status = FlightStatus.InFlight, AircraftId = 4, RouteId = 5 },
            //    new Flight { FlightNumber = "OA1500", DepartureUtc = new DateTime(2025, 9, 4, 23, 0, 0), ArrivalUtc = new DateTime(2025, 9, 4, 2, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 5, RouteId = 6 },
            //    new Flight { FlightNumber = "PA1600", DepartureUtc = new DateTime(2025, 9, 5, 0, 0, 0), ArrivalUtc = new DateTime(2025, 9, 5, 3, 0, 0), Status = FlightStatus.Landed, AircraftId = 6, RouteId = 7 },
            //    new Flight { FlightNumber = "QA1700", DepartureUtc = new DateTime(2025, 9, 6, 1, 0, 0), ArrivalUtc = new DateTime(2025, 9, 6, 4, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
            //    new Flight { FlightNumber = "RA1800", DepartureUtc = new DateTime(2025, 9, 7, 2, 0, 0), ArrivalUtc = new DateTime(2025, 9, 7, 5, 0, 0), Status = FlightStatus.Delayed, AircraftId = 8, RouteId = 9 },
            //    new Flight { FlightNumber = "SA1900", DepartureUtc = new DateTime(2025, 9, 8, 3, 0, 0), ArrivalUtc = new DateTime(2025, 9, 8, 6, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
            //    new Flight { FlightNumber = "TA2000", DepartureUtc = new DateTime(2025, 9, 9, 4, 0, 0), ArrivalUtc = new DateTime(2025, 9, 9, 7, 0, 0), Status = FlightStatus.InFlight, AircraftId = 10, RouteId = 1 },
            //    new Flight { FlightNumber = "UA2100", DepartureUtc = new DateTime(2025, 9, 10, 5, 0, 0), ArrivalUtc = new DateTime(2025, 9, 10, 8, 0, 0), Status = FlightStatus.Landed, AircraftId = 1, RouteId = 2 },
            //    new Flight { FlightNumber = "VA2200", DepartureUtc = new DateTime(2025, 9, 11, 6, 0, 0), ArrivalUtc = new DateTime(2025, 9, 11, 9, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 2, RouteId = 3 },
            //    new Flight { FlightNumber = "WA2300", DepartureUtc = new DateTime(2025, 9, 12, 7, 0, 0), ArrivalUtc = new DateTime(2025, 9, 12, 10, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 3, RouteId = 4 },
            //    new Flight { FlightNumber = "XA2400", DepartureUtc = new DateTime(2025, 9, 13, 8, 0, 0), ArrivalUtc = new DateTime(2025, 9, 13, 11, 0, 0), Status = FlightStatus.Cancelled, AircraftId = 4, RouteId = 5 },
            //    new Flight { FlightNumber = "YA2500", DepartureUtc = new DateTime(2025, 9, 14, 9, 0, 0), ArrivalUtc = new DateTime(2025, 9, 14, 12, 0, 0), Status = FlightStatus.Landed, AircraftId = 5, RouteId = 6 },
            //    new Flight { FlightNumber = "ZA2600", DepartureUtc = new DateTime(2025, 9, 15, 10, 0, 0), ArrivalUtc = new DateTime(2025, 9, 15, 13, 0, 0), Status = FlightStatus.InFlight, AircraftId = 6, RouteId = 7 },
            //    new Flight { FlightNumber = "AA2700", DepartureUtc = new DateTime(2025, 9, 16, 11, 0, 0), ArrivalUtc = new DateTime(2025, 9, 16, 14, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
            //    new Flight { FlightNumber = "BA2800", DepartureUtc = new DateTime(2025, 9, 17, 12, 0, 0), ArrivalUtc = new DateTime(2025, 9, 17, 15, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 8, RouteId = 9 },
            //    new Flight { FlightNumber = "CA2900", DepartureUtc = new DateTime(2025, 9, 18, 13, 0, 0), ArrivalUtc = new DateTime(2025, 9, 18, 16, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
            //    new Flight { FlightNumber = "DA3000", DepartureUtc = new DateTime(2025, 9, 19, 14, 0, 0), ArrivalUtc = new DateTime(2025, 9, 19, 17, 0, 0), Status = FlightStatus.Cancelled, AircraftId = 10, RouteId = 1 }

            //    );


            //// Crew Members (20)
            //modelBuilder.Entity<CrewMember>().HasData(
            //    new CrewMember { FullName = "Salim Alsalami", Role = CrewRole.Pilot, LicenseNo = "12341" },
            //    new CrewMember { FullName = "Ali Alsinani", Role = CrewRole.CoPilot, LicenseNo = "12322" },
            //    new CrewMember { FullName = "Fatima Alharthy", Role = CrewRole.FlightAttendant, LicenseNo = "12333" },
            //    new CrewMember { FullName = "Ahmed Alghamdi", Role = CrewRole.Pilot, LicenseNo = "12344" },
            //    new CrewMember { FullName = "Sara Albalushi", Role = CrewRole.CoPilot, LicenseNo = "12355" },
            //    new CrewMember { FullName = "Hassan Alhajri", Role = CrewRole.FlightAttendant, LicenseNo = "12366" },
            //    new CrewMember { FullName = "Layla Alshamsi", Role = CrewRole.Pilot, LicenseNo = "12377" },
            //    new CrewMember { FullName = "Omar Alharthy", Role = CrewRole.CoPilot, LicenseNo = "12388" },
            //    new CrewMember { FullName = "Noura Alghamdi", Role = CrewRole.FlightAttendant, LicenseNo = "12399" },
            //    new CrewMember { FullName = "Yusuf Albalushi", Role = CrewRole.Pilot, LicenseNo = "12400" },
            //    new CrewMember { FullName = "Aisha Alhajri", Role = CrewRole.CoPilot, LicenseNo = "12411" },
            //    new CrewMember { FullName = "Khalid Alshamsi", Role = CrewRole.FlightAttendant, LicenseNo = "12422" },
            //    new CrewMember { FullName = "Zainab Alsalami", Role = CrewRole.Pilot, LicenseNo = "12433" },
            //    new CrewMember { FullName = "Mohammed Alsinani", Role = CrewRole.CoPilot, LicenseNo = "12444" },
            //    new CrewMember { FullName = "Fatimah Alharthy", Role = CrewRole.FlightAttendant, LicenseNo = "12455" },
            //    new CrewMember { FullName = "Hamad Alghamdi", Role = CrewRole.Pilot, LicenseNo = "12466" },
            //    new CrewMember { FullName = "Mariam Albalushi", Role = CrewRole.CoPilot, LicenseNo = "12477" },
            //    new CrewMember { FullName = "Sultan Alhajri", Role = CrewRole.FlightAttendant, LicenseNo = "12488" },
            //    new CrewMember { FullName = "Ranya Alshamsi", Role = CrewRole.Pilot, LicenseNo = "12499" },
            //    new CrewMember { FullName = "Tariq Alsalami", Role = CrewRole.CoPilot, LicenseNo = "12500" },
            //    new CrewMember { FullName = "Laila Alsinani", Role = CrewRole.FlightAttendant, LicenseNo = "12511" }





            //);


            //// Routes (20) 
            //modelBuilder.Entity<Route>().HasData(
            //    new Route { DistanceKm = 5000, OriginAirportId = 1, DestinationAirportId = 2 },
            //    new Route { DistanceKm = 3000, OriginAirportId = 2, DestinationAirportId = 3 },
            //    new Route { DistanceKm = 4000, OriginAirportId = 3, DestinationAirportId = 4 },
            //    new Route { DistanceKm = 6000, OriginAirportId = 4, DestinationAirportId = 5 },
            //    new Route { DistanceKm = 7000, OriginAirportId = 5, DestinationAirportId = 6 },
            //    new Route { DistanceKm = 8000, OriginAirportId = 6, DestinationAirportId = 7 },
            //    new Route { DistanceKm = 9000, OriginAirportId = 7, DestinationAirportId = 8 },
            //    new Route { DistanceKm = 10000, OriginAirportId = 8, DestinationAirportId = 9 },
            //    new Route { DistanceKm = 11000, OriginAirportId = 9, DestinationAirportId = 10 },
            //    new Route { DistanceKm = 12000, OriginAirportId = 10, DestinationAirportId = 1 },
            //    new Route { DistanceKm = 13000, OriginAirportId = 1, DestinationAirportId = 3 },
            //    new Route { DistanceKm = 14000, OriginAirportId = 2, DestinationAirportId = 4 },
            //    new Route { DistanceKm = 15000, OriginAirportId = 3, DestinationAirportId = 5 },
            //    new Route { DistanceKm = 16000, OriginAirportId = 4, DestinationAirportId = 6 },
            //    new Route { DistanceKm = 17000, OriginAirportId = 5, DestinationAirportId = 7 },
            //    new Route { DistanceKm = 18000, OriginAirportId = 6, DestinationAirportId = 8 },
            //    new Route { DistanceKm = 19000, OriginAirportId = 7, DestinationAirportId = 9 },
            //    new Route { DistanceKm = 20000, OriginAirportId = 8, DestinationAirportId = 10 },
            //    new Route { DistanceKm = 21000, OriginAirportId = 9, DestinationAirportId = 1 },
            //    new Route { DistanceKm = 22000, OriginAirportId = 10, DestinationAirportId = 2 }
            //);

            //// Passengers (50)

            //modelBuilder.Entity<Passenger>().HasData(
            //    new Passenger { FullName = "Salim Alsalami", PassportNo = "111111", Nationality = "112211", DOB = new DateTime(1990, 1, 1) },
            //    new Passenger { FullName = "Ali Alsinani", PassportNo = "222222", Nationality = "223322", DOB = new DateTime(1992, 2, 2) },
            //    new Passenger { FullName = "Salim Alsalami", PassportNo = "111111", Nationality = "Omani", DOB = new DateTime(1990, 1, 1) },
            //    new Passenger { FullName = "Ali Alsinani", PassportNo = "222222", Nationality = "Omani", DOB = new DateTime(1992, 2, 2) },
            //    new Passenger { FullName = "Fatima Alhabsi", PassportNo = "333333", Nationality = "Omani", DOB = new DateTime(1995, 3, 3) },
            //    new Passenger { FullName = "Mohammed Albalushi", PassportNo = "444444", Nationality = "Omani", DOB = new DateTime(1988, 4, 4) },
            //    new Passenger { FullName = "Aisha Alharthy", PassportNo = "555555", Nationality = "Omani", DOB = new DateTime(1993, 5, 5) },
            //    new Passenger { FullName = "Hassan Alshibli", PassportNo = "666666", Nationality = "Omani", DOB = new DateTime(1989, 6, 6) },
            //    new Passenger { FullName = "Maryam Alkindi", PassportNo = "777777", Nationality = "Omani", DOB = new DateTime(1991, 7, 7) },
            //    new Passenger { FullName = "Yousef Alshamsi", PassportNo = "888888", Nationality = "Omani", DOB = new DateTime(1994, 8, 8) },
            //    new Passenger { FullName = "Noor Alzadjali", PassportNo = "999999", Nationality = "Omani", DOB = new DateTime(1996, 9, 9) },
            //    new Passenger { FullName = "Said Alhaddabi", PassportNo = "101010", Nationality = "Omani", DOB = new DateTime(1987, 10, 10) },
            //    new Passenger { FullName = "John Smith", PassportNo = "A123456", Nationality = "British", DOB = new DateTime(1985, 11, 11) },
            //    new Passenger { FullName = "Emily Johnson", PassportNo = "B234567", Nationality = "Canadian", DOB = new DateTime(1990, 12, 12) },
            //    new Passenger { FullName = "Michael Brown", PassportNo = "C345678", Nationality = "American", DOB = new DateTime(1983, 1, 13) },
            //    new Passenger { FullName = "Sophia Davis", PassportNo = "D456789", Nationality = "Australian", DOB = new DateTime(1992, 2, 14) },
            //    new Passenger { FullName = "Daniel Wilson", PassportNo = "E567890", Nationality = "German", DOB = new DateTime(1988, 3, 15) },
            //    new Passenger { FullName = "Liam Thompson", PassportNo = "F678901", Nationality = "Irish", DOB = new DateTime(1995, 4, 16) },
            //    new Passenger { FullName = "Olivia Martinez", PassportNo = "G789012", Nationality = "Spanish", DOB = new DateTime(1994, 5, 17) },
            //    new Passenger { FullName = "Noah Anderson", PassportNo = "H890123", Nationality = "Swedish", DOB = new DateTime(1989, 6, 18) },
            //    new Passenger { FullName = "Emma White", PassportNo = "I901234", Nationality = "French", DOB = new DateTime(1993, 7, 19) },
            //    new Passenger { FullName = "Omar Alharthy", PassportNo = "333333", Nationality = "OM", DOB = new DateTime(1991, 3, 3) },
            //    new Passenger { FullName = "Fatma Albalushi", PassportNo = "444444", Nationality = "OM", DOB = new DateTime(1988, 4, 4) },
            //    new Passenger { FullName = "Maryam Alrashdi", PassportNo = "555555", Nationality = "OM", DOB = new DateTime(1995, 5, 5) },
            //    new Passenger { FullName = "Ahmed Alkindi", PassportNo = "666666", Nationality = "OM", DOB = new DateTime(1985, 6, 6) },
            //    new Passenger { FullName = "Khalid Alhabsi", PassportNo = "777777", Nationality = "OM", DOB = new DateTime(1994, 7, 7) },
            //    new Passenger { FullName = "Mona Alshanfari", PassportNo = "888888", Nationality = "OM", DOB = new DateTime(1993, 8, 8) },
            //    new Passenger { FullName = "Huda Alnaqbi", PassportNo = "999999", Nationality = "OM", DOB = new DateTime(1990, 9, 9) },
            //    new Passenger { FullName = "Nasser Alazri", PassportNo = "101010", Nationality = "OM", DOB = new DateTime(1989, 10, 10) },
            //    new Passenger { FullName = "Aisha Alsaadi", PassportNo = "111112", Nationality = "OM", DOB = new DateTime(1996, 11, 11) },
            //    new Passenger { FullName = "Said Almamari", PassportNo = "121212", Nationality = "OM", DOB = new DateTime(1992, 12, 12) },
            //    new Passenger { FullName = "Layla Almaskari", PassportNo = "131313", Nationality = "OM", DOB = new DateTime(1994, 1, 13) },
            //    new Passenger { FullName = "Majid Alhinai", PassportNo = "141414", Nationality = "OM", DOB = new DateTime(1995, 2, 14) },
            //    new Passenger { FullName = "Hassan Alrawahi", PassportNo = "151515", Nationality = "OM", DOB = new DateTime(1991, 3, 15) },
            //    new Passenger { FullName = "Sara Alzubair", PassportNo = "161616", Nationality = "OM", DOB = new DateTime(1990, 4, 16) },
            //    new Passenger { FullName = "Yousef Alriyami", PassportNo = "171717", Nationality = "OM", DOB = new DateTime(1988, 5, 17) },
            //    new Passenger { FullName = "Rashid Alameri", PassportNo = "181818", Nationality = "OM", DOB = new DateTime(1993, 6, 18) },
            //    new Passenger { FullName = "Maha Alkaabi", PassportNo = "191919", Nationality = "OM", DOB = new DateTime(1989, 7, 19) },
            //    new Passenger { FullName = "Khalifa Alketbi", PassportNo = "202020", Nationality = "OM", DOB = new DateTime(1994, 8, 20) },
            //    new Passenger { FullName = "Hind Alharmoodi", PassportNo = "212121", Nationality = "OM", DOB = new DateTime(1991, 9, 21) },
            //    new Passenger { FullName = "Noor Almeqbali", PassportNo = "222223", Nationality = "OM", DOB = new DateTime(1992, 10, 22) },
            //    new Passenger { FullName = "Juma Alnaqbi", PassportNo = "232323", Nationality = "OM", DOB = new DateTime(1990, 11, 23) },
            //    new Passenger { FullName = "Amal Almansoori", PassportNo = "242424", Nationality = "OM", DOB = new DateTime(1987, 12, 24) },
            //    new Passenger { FullName = "Hamad Almansoor", PassportNo = "252525", Nationality = "OM", DOB = new DateTime(1995, 1, 25) },
            //    new Passenger { FullName = "Reem Alsaqri", PassportNo = "262626", Nationality = "OM", DOB = new DateTime(1991, 2, 26) },
            //    new Passenger { FullName = "Ali Alwahabi", PassportNo = "272727", Nationality = "OM", DOB = new DateTime(1993, 3, 27) },
            //    new Passenger { FullName = "Fatma Alhashmi", PassportNo = "282828", Nationality = "OM", DOB = new DateTime(1994, 4, 28) },
            //    new Passenger { FullName = "Salim Almahrouqi", PassportNo = "292929", Nationality = "OM", DOB = new DateTime(1988, 5, 29) },
            //    new Passenger { FullName = "Maryam Alblushi", PassportNo = "303030", Nationality = "OM", DOB = new DateTime(1992, 6, 30) },
            //    new Passenger { FullName = "Othman Alsinani", PassportNo = "313131", Nationality = "OM", DOB = new DateTime(1990, 7, 31) }
            //    );


            //// Bookings (10)
            //modelBuilder.Entity<Booking>().HasData(
            //    new Booking { BookingId = 1, BookingRef = "BK0001", BookingDate = new DateTime(2025, 8, 20), Status = BookingStatus.Confirmed, PassengerId = 1 },
            //    new Booking { BookingId = 2, BookingRef = "BK0002", BookingDate = new DateTime(2025, 8, 21), Status = BookingStatus.Cancelled, PassengerId = 2 },
            //    new Booking { BookingId = 3, BookingRef = "BK0003", BookingDate = new DateTime(2025, 8, 22), Status = BookingStatus.Confirmed, PassengerId = 3 },
            //    new Booking { BookingId = 4, BookingRef = "BK0004", BookingDate = new DateTime(2025, 8, 23), Status = BookingStatus.Pending, PassengerId = 4 },
            //    new Booking { BookingId = 5, BookingRef = "BK0005", BookingDate = new DateTime(2025, 8, 24), Status = BookingStatus.Confirmed, PassengerId = 5 },
            //    new Booking { BookingId = 6, BookingRef = "BK0006", BookingDate = new DateTime(2025, 8, 25), Status = BookingStatus.Cancelled, PassengerId = 6 },
            //    new Booking { BookingId = 7, BookingRef = "BK0007", BookingDate = new DateTime(2025, 8, 26), Status = BookingStatus.Confirmed, PassengerId = 7 },
            //    new Booking { BookingId = 8, BookingRef = "BK0008", BookingDate = new DateTime(2025, 8, 27), Status = BookingStatus.Pending, PassengerId = 8 },
            //    new Booking { BookingId = 9, BookingRef = "BK0009", BookingDate = new DateTime(2025, 8, 28), Status = BookingStatus.Confirmed, PassengerId = 9 },
            //    new Booking { BookingId = 10, BookingRef = "BK0010", BookingDate = new DateTime(2025, 8, 29), Status = BookingStatus.Cancelled, PassengerId = 10 }


            //);


            //// Tickets (20)
            //modelBuilder.Entity<Ticket>().HasData(
            //    new Ticket { SeatNumber = "1A", Fare = 500.00m, CheckedIn = true, BookingId = 1, FlightId = 1 },
            //    new Ticket { SeatNumber = "1B", Fare = 600.00m, CheckedIn = false, BookingId = 2, FlightId = 2 },
            //    new Ticket { SeatNumber = "1C", Fare = 550.00m, CheckedIn = true, BookingId = 3, FlightId = 3 },
            //    new Ticket { SeatNumber = "1D", Fare = 700.00m, CheckedIn = false, BookingId = 4, FlightId = 4 },
            //    new Ticket { SeatNumber = "1E", Fare = 650.00m, CheckedIn = true, BookingId = 5, FlightId = 5 },
            //    new Ticket { SeatNumber = "1F", Fare = 800.00m, CheckedIn = false, BookingId = 6, FlightId = 6 },
            //    new Ticket { SeatNumber = "2A", Fare = 520.00m, CheckedIn = true, BookingId = 7, FlightId = 7 },
            //    new Ticket { SeatNumber = "2B", Fare = 620.00m, CheckedIn = false, BookingId = 8, FlightId = 8 },
            //    new Ticket { SeatNumber = "2C", Fare = 570.00m, CheckedIn = true, BookingId = 9, FlightId = 9 },
            //    new Ticket { SeatNumber = "2D", Fare = 720.00m, CheckedIn = false, BookingId = 10, FlightId = 10 },
            //    new Ticket { SeatNumber = "3A", Fare = 530.00m, CheckedIn = true, BookingId = 1, FlightId = 11 },
            //    new Ticket { SeatNumber = "3B", Fare = 630.00m, CheckedIn = false, BookingId = 2, FlightId = 12 },
            //    new Ticket { SeatNumber = "3C", Fare = 580.00m, CheckedIn = true, BookingId = 3, FlightId = 13 },
            //    new Ticket { SeatNumber = "3D", Fare = 730.00m, CheckedIn = false, BookingId = 4, FlightId = 14 },
            //    new Ticket { SeatNumber = "3E", Fare = 680.00m, CheckedIn = true, BookingId = 5, FlightId = 15 },
            //    new Ticket { SeatNumber = "3F", Fare = 830.00m, CheckedIn = false, BookingId = 6, FlightId = 16 },
            //    new Ticket { SeatNumber = "4A", Fare = 540.00m, CheckedIn = true, BookingId = 7, FlightId = 17 },
            //    new Ticket { SeatNumber = "4B", Fare = 640.00m, CheckedIn = false, BookingId = 8, FlightId = 18 },
            //    new Ticket { SeatNumber = "4C", Fare = 590.00m, CheckedIn = true, BookingId = 9, FlightId = 19 },
            //    new Ticket { SeatNumber = "4D", Fare = 740.00m, CheckedIn = false, BookingId = 10, FlightId = 20 }


            //);



            //// Baggages (20)
            //modelBuilder.Entity<Baggage>().HasData(
            //    new Baggage { WeightKg = 20, TagNumber = "TAG001", TicketId = 1 },
            //    new Baggage { WeightKg = 25, TagNumber = "TAG002", TicketId = 2 },
            //    new Baggage { WeightKg = 15, TagNumber = "TAG003", TicketId = 3 },
            //    new Baggage { WeightKg = 30, TagNumber = "TAG004", TicketId = 4 },
            //    new Baggage { WeightKg = 22, TagNumber = "TAG005", TicketId = 5 },
            //    new Baggage { WeightKg = 18, TagNumber = "TAG006", TicketId = 6 },
            //    new Baggage { WeightKg = 28, TagNumber = "TAG007", TicketId = 7 },
            //    new Baggage { WeightKg = 24, TagNumber = "TAG008", TicketId = 8 },
            //    new Baggage { WeightKg = 19, TagNumber = "TAG009", TicketId = 9 },
            //    new Baggage { WeightKg = 21, TagNumber = "TAG010", TicketId = 10 },
            //    new Baggage { WeightKg = 23, TagNumber = "TAG011", TicketId = 11 },
            //    new Baggage { WeightKg = 26, TagNumber = "TAG012", TicketId = 12 },
            //    new Baggage { WeightKg = 17, TagNumber = "TAG013", TicketId = 13 },
            //    new Baggage { WeightKg = 29, TagNumber = "TAG014", TicketId = 14 },
            //    new Baggage { WeightKg = 20, TagNumber = "TAG015", TicketId = 15 },
            //    new Baggage { WeightKg = 25, TagNumber = "TAG016", TicketId = 16 },
            //    new Baggage { WeightKg = 15, TagNumber = "TAG017", TicketId = 17 },
            //    new Baggage { WeightKg = 30, TagNumber = "TAG018", TicketId = 18 },
            //    new Baggage { WeightKg = 22, TagNumber = "TAG019", TicketId = 19 },
            //    new Baggage { WeightKg = 18, TagNumber = "TAG020", TicketId = 20 }
            //);

            //// AircraftMaintenance (10)
            //if (!_flightRepository.GetAll().Any())
            //{
            //    var aircraftsMaintenance = new List<AircraftMaintenance>
            //    {
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 20), Type = "Engine Inspection", Notes = "Engine check", AircraftId = 1 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 21), Type = "Tire Replacement", Notes = "Replaced front tires", AircraftId = 2 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 22), Type = "Fuel System Check", Notes = "Checked fuel lines", AircraftId = 3 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 23), Type = "Avionics Upgrade", Notes = "Upgraded navigation system", AircraftId = 4 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 24), Type = "Hydraulic System Check", Notes = "Checked hydraulic fluid levels", AircraftId = 5 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 25), Type = "Air Conditioning Service", Notes = "Serviced air conditioning system", AircraftId = 6 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 26), Type = "Landing Gear Inspection", Notes = "Inspected landing gear", AircraftId = 7 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 27), Type = "Electrical System Check", Notes = "Checked electrical systems", AircraftId = 8 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 28), Type = "Cabin Pressure Test", Notes = "Tested cabin pressure systems", AircraftId = 9 },
            //        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 29), Type = "Safety Equipment Check", Notes = "Checked safety equipment", AircraftId = 10 }
            //    };


            //    foreach (var maintenance in aircraftsMaintenance) _flightRepository.Add(maintenance);

                

            //}



        }
    }

}
