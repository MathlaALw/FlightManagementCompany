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

        
        private readonly FlightRepository _flightRepository;
        private readonly AircraftRepository _aircraftRepository;
        private readonly RouteRepository _routeRepository;
        private readonly TicketRepository _ticketRepository;
        private readonly FlightCrewRepository _flightCrewRepository;
        private readonly CrewMemberRepository _flightCrewMemberRepository;
        private readonly AircraftMaintenanceRepository _aircraftMaintenanceRepository;
        private readonly AirportRepository _airportRepository;
        private readonly PassengerRepository _passengerRepository;
        private readonly BookingRepository _bookingRepository;
        private readonly BaggageRepository _baggageRepository;

        public FlightService(FlightDbContext context)
        {
            _flightRepository = new FlightRepository(context);
            _aircraftRepository = new AircraftRepository(context);
            _routeRepository = new RouteRepository(context);
            _ticketRepository = new TicketRepository(context);
            _flightCrewRepository = new FlightCrewRepository(context);
            _flightCrewMemberRepository = new CrewMemberRepository(context);
            _aircraftMaintenanceRepository = new AircraftMaintenanceRepository(context);
            _airportRepository = new AirportRepository(context);
            _passengerRepository = new PassengerRepository(context);
            _bookingRepository = new BookingRepository(context);
            _baggageRepository = new BaggageRepository(context);
        }

        public void CreateSampleData()
        {
            //1. Aircraft data creation
            if (!_aircraftRepository.GetAll().Any())
            {
                var aircrafts = new List<Aircraft>
                    {
                        new Aircraft { Model = "Boeing 777", Capacity = 396 },
                        new Aircraft { Model = "Airbus A380", Capacity = 555 },
                        new Aircraft { Model = "Boeing 737", Capacity = 189 },
                        new Aircraft { Model = "Airbus A320", Capacity = 180 },
                        new Aircraft { Model = "Boeing 787", Capacity = 242 },
                        new Aircraft { Model = "Airbus A350", Capacity = 440 },
                        new Aircraft { Model = "Boeing 747", Capacity = 660 },
                        new Aircraft { Model = "Airbus A330", Capacity = 277 },
                        new Aircraft { Model = "Boeing 767", Capacity = 216 },
                        new Aircraft { Model = "Airbus A220", Capacity = 120 }
                    };
                foreach (var aircraft in aircrafts)
                {
                    _aircraftRepository.Add(aircraft);
                }
            }
            //2. Airport data creation
            if (!_airportRepository.GetAll().Any())
            {
                var airports = new List<Airport>
                    {
                         new Airport { IATA = "JFK", Name = "John F. Kennedy", City = "New York", Country = "USA", TimeZone = "America/New_York" },
                         new Airport { IATA = "LHR", Name = "Heathrow", City = "London", Country = "UK", TimeZone = "Europe/London" },
                         new Airport { IATA = "MCT", Name = "Muscat International", City = "Muscat", Country = "Oman", TimeZone = "Asia/Muscat" },
                         new Airport { IATA = "DXB", Name = "Dubai Intl", City = "Dubai", Country = "UAE", TimeZone = "Asia/Dubai" },
                         new Airport { IATA = "SIN", Name = "Changi", City = "Singapore", Country = "Singapore", TimeZone = "Asia/Singapore" },
                         new Airport { IATA = "LAX", Name = "Los Angeles Intl", City = "Los Angeles", Country = "USA", TimeZone = "America/Los_Angeles" },
                         new Airport { IATA = "CDG", Name = "Charles de Gaulle", City = "Paris", Country = "France", TimeZone = "Europe/Paris" },
                         new Airport { IATA = "FRA", Name = "Frankfurt", City = "Frankfurt", Country = "Germany", TimeZone = "Europe/Berlin" },
                         new Airport { IATA = "BOM", Name = "Chhatrapati Shivaji", City = "Mumbai", Country = "India", TimeZone = "Asia/Kolkata" },
                         new Airport { IATA = "SYD", Name = "Sydney Kingsford Smith", City = "Sydney", Country = "Australia", TimeZone = "Australia/Sydney" }
                    };
                foreach (var airport in airports)
                {
                    _airportRepository.Add(airport);
                }
            }
            //3. Route data creation
            if (!_routeRepository.GetAll().Any())
            {
                var routes = new List<Route>
                    {
                                new Route { DistanceKm = 5000, OriginAirportId = 1, DestinationAirportId = 2 },
                                new Route { DistanceKm = 3000, OriginAirportId = 2, DestinationAirportId = 3 },
                                new Route { DistanceKm = 4000, OriginAirportId = 3, DestinationAirportId = 4 },
                                new Route { DistanceKm = 6000, OriginAirportId = 4, DestinationAirportId = 5 },
                                new Route { DistanceKm = 7000, OriginAirportId = 5, DestinationAirportId = 6 },
                                new Route { DistanceKm = 8000, OriginAirportId = 6, DestinationAirportId = 7 },
                                new Route { DistanceKm = 9000, OriginAirportId = 7, DestinationAirportId = 8 },
                                new Route { DistanceKm = 10000, OriginAirportId = 8, DestinationAirportId = 9 },
                                new Route { DistanceKm = 11000, OriginAirportId = 9, DestinationAirportId = 10 },
                                new Route { DistanceKm = 12000, OriginAirportId = 10, DestinationAirportId = 1 },
                                new Route { DistanceKm = 13000, OriginAirportId = 1, DestinationAirportId = 3 },
                                new Route { DistanceKm = 14000, OriginAirportId = 2, DestinationAirportId = 4 },
                                new Route { DistanceKm = 15000, OriginAirportId = 3, DestinationAirportId = 5 },
                                new Route { DistanceKm = 16000, OriginAirportId = 4, DestinationAirportId = 6 },
                                new Route { DistanceKm = 17000, OriginAirportId = 5, DestinationAirportId = 7 },
                                new Route { DistanceKm = 18000, OriginAirportId = 6, DestinationAirportId = 8 },
                                new Route { DistanceKm = 19000, OriginAirportId = 7, DestinationAirportId = 9 },
                                new Route { DistanceKm = 20000, OriginAirportId = 8, DestinationAirportId = 10 },
                                new Route { DistanceKm = 21000, OriginAirportId = 9, DestinationAirportId = 1 },
                                new Route { DistanceKm = 22000, OriginAirportId = 10, DestinationAirportId = 2 }
                    };
                foreach (var route in routes)
                {
                    _routeRepository.Add(route);
                }
            }
            //4. Booking data creation
            if (!_bookingRepository.GetAll().Any())
            {
                var bookings = new List<Booking>
                {
                    new Booking { BookingId = 1, BookingRef = "BK0001", BookingDate = new DateTime(2025, 8, 20), Status = BookingStatus.Confirmed, PassengerId = 1 },
                    new Booking { BookingId = 2, BookingRef = "BK0002", BookingDate = new DateTime(2025, 8, 21), Status = BookingStatus.Cancelled, PassengerId = 2 },
                    new Booking { BookingId = 3, BookingRef = "BK0003", BookingDate = new DateTime(2025, 8, 22), Status = BookingStatus.Confirmed, PassengerId = 3 },
                    new Booking { BookingId = 4, BookingRef = "BK0004", BookingDate = new DateTime(2025, 8, 23), Status = BookingStatus.Pending, PassengerId = 4 },
                    new Booking { BookingId = 5, BookingRef = "BK0005", BookingDate = new DateTime(2025, 8, 24), Status = BookingStatus.Confirmed, PassengerId = 5 },
                    new Booking { BookingId = 6, BookingRef = "BK0006", BookingDate = new DateTime(2025, 8, 25), Status = BookingStatus.Cancelled, PassengerId = 6 },
                    new Booking { BookingId = 7, BookingRef = "BK0007", BookingDate = new DateTime(2025, 8, 26), Status = BookingStatus.Confirmed, PassengerId = 7 },
                    new Booking { BookingId = 8, BookingRef = "BK0008", BookingDate = new DateTime(2025, 8, 27), Status = BookingStatus.Pending, PassengerId = 8 },
                    new Booking { BookingId = 9, BookingRef = "BK0009", BookingDate = new DateTime(2025, 8, 28), Status = BookingStatus.Confirmed, PassengerId = 9 },
                    new Booking { BookingId = 10, BookingRef = "BK0010", BookingDate = new DateTime(2025, 8, 29), Status = BookingStatus.Cancelled, PassengerId = 10 }
                };
                foreach (var booking in bookings)
                {
                    _bookingRepository.Add(booking);
                }
            }


            //5. Passenger data creation
            if (!_passengerRepository.GetAll().Any())
            {
                var passengers = new List<Passenger>
                {
                    new Passenger { FullName = "Salim Alsalami", PassportNo = "111111", Nationality = "Omani", DOB = new DateTime(1990, 1, 1) },
                    new Passenger { FullName = "Ali Alsinani", PassportNo = "22332", Nationality = "Omani", DOB = new DateTime(1992, 2, 2) },
                    new Passenger { FullName = "Salim Alsalami", PassportNo = "11311", Nationality = "Omani", DOB = new DateTime(1990, 1, 1) },
                    new Passenger { FullName = "Ali Alsinani", PassportNo = "22322", Nationality = "Omani", DOB = new DateTime(1992, 2, 2) },
                    new Passenger { FullName = "Fatima Alhabsi", PassportNo = "33353", Nationality = "Omani", DOB = new DateTime(1995, 3, 3) },
                    new Passenger { FullName = "Mohammed Albalushi", PassportNo = "4464", Nationality = "Omani", DOB = new DateTime(1988, 4, 4) },
                    new Passenger { FullName = "Aisha Alharthy", PassportNo = "5455", Nationality = "Omani", DOB = new DateTime(1993, 5, 5) },
                    new Passenger { FullName = "Othman Alsinani", PassportNo = "313131", Nationality = "Omani", DOB = new DateTime(1990, 7, 31) }
                };

                foreach (var passenger in passengers)
                {
                    _passengerRepository.Add(passenger);
                }
            }

            //6. Aircraft Maintenance data creation
            if (!_aircraftMaintenanceRepository.GetAll().Any())
            {
                var aircraftMaintenances = new List<AircraftMaintenance>
                    {
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 20), Type = "Engine Inspection", Notes = "Engine check", AircraftId = 1 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 21), Type = "Tire Replacement", Notes = "Replaced front tires", AircraftId = 2 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 22), Type = "Fuel System Check", Notes = "Checked fuel lines", AircraftId = 3 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 23), Type = "Avionics Upgrade", Notes = "Upgraded navigation system", AircraftId = 4 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 24), Type = "Hydraulic System Check", Notes = "Checked hydraulic fluid levels", AircraftId = 5 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 25), Type = "Air Conditioning Service", Notes = "Serviced air conditioning system", AircraftId = 6 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 26), Type = "Landing Gear Inspection", Notes = "Inspected landing gear", AircraftId = 7 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 27), Type = "Electrical System Check", Notes = "Checked electrical systems", AircraftId = 8 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 28), Type = "Cabin Pressure Test", Notes = "Tested cabin pressure systems", AircraftId = 9 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 29), Type = "Safety Equipment Check", Notes = "Checked safety equipment", AircraftId = 10 }
                    };
                foreach (var maintenance in aircraftMaintenances)
                {
                    _aircraftMaintenanceRepository.Add(maintenance);
                }
            }

            //7. Flight data creation
            if (!_flightRepository.GetAll().Any())
            {
                var flights = new List<Flight>
                {
                            new Flight { FlightNumber = "AA100", DepartureUtc = new DateTime(2025, 8, 21, 9, 0, 0), ArrivalUtc = new DateTime(2025, 8, 21, 12, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 1, RouteId = 2 },
                            new Flight { FlightNumber = "BA200", DepartureUtc = new DateTime(2025, 8, 22, 10, 0, 0), ArrivalUtc = new DateTime(2025, 8, 22, 13, 0, 0), Status = FlightStatus.InFlight, AircraftId = 2, RouteId = 3 },
                            new Flight { FlightNumber = "CA300", DepartureUtc = new DateTime(2025, 8, 23, 11, 0, 0), ArrivalUtc = new DateTime(2025, 8, 23, 14, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 3, RouteId = 4 },
                            new Flight { FlightNumber = "DA400", DepartureUtc = new DateTime(2025, 8, 24, 12, 0, 0), ArrivalUtc = new DateTime(2025, 8, 24, 15, 0, 0), Status = FlightStatus.Landed, AircraftId = 4, RouteId = 5 },
                            new Flight { FlightNumber = "EA500", DepartureUtc = new DateTime(2025, 8, 25, 13, 0, 0), ArrivalUtc = new DateTime(2025, 8, 25, 16, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 5, RouteId = 6 },
                            new Flight { FlightNumber = "FA600", DepartureUtc = new DateTime(2025, 8, 26, 14, 0, 0), ArrivalUtc = new DateTime(2025, 8, 26, 17, 0, 0), Status = FlightStatus.InFlight, AircraftId = 6, RouteId = 7 },
                            new Flight { FlightNumber = "GA700", DepartureUtc = new DateTime(2025, 8, 27, 15, 0, 0), ArrivalUtc = new DateTime(2025, 8, 27, 18, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
                            new Flight { FlightNumber = "HA800", DepartureUtc = new DateTime(2025, 8, 28, 16, 0, 0), ArrivalUtc = new DateTime(2025, 8, 28, 19, 0, 0), Status = FlightStatus.Landed, AircraftId = 8, RouteId = 9 },
                            new Flight { FlightNumber = "IA900", DepartureUtc = new DateTime(2025, 8, 29, 17, 0, 0), ArrivalUtc = new DateTime(2025, 8, 29, 20, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
                            new Flight { FlightNumber = "JA1000", DepartureUtc = new DateTime(2025, 8, 30, 18, 0, 0), ArrivalUtc = new DateTime(2025, 8, 30, 21, 0, 0), Status = FlightStatus.InFlight, AircraftId = 10, RouteId = 1 },
                            new Flight { FlightNumber = "KA1100", DepartureUtc = new DateTime(2025, 8, 31, 19, 0, 0), ArrivalUtc = new DateTime(2025, 8, 31, 22, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 1, RouteId = 2 },
                            new Flight { FlightNumber = "LA1200", DepartureUtc = new DateTime(2025, 9, 1, 20, 0, 0), ArrivalUtc = new DateTime(2025, 9, 1, 23, 0, 0), Status = FlightStatus.Landed, AircraftId = 2, RouteId = 3 },
                            new Flight { FlightNumber = "MA1300", DepartureUtc = new DateTime(2025, 9, 2, 21, 0, 0), ArrivalUtc = new DateTime(2025, 9, 2, 0, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 3, RouteId = 4 },
                            new Flight { FlightNumber = "NA1400", DepartureUtc = new DateTime(2025, 9, 3, 22, 0, 0), ArrivalUtc = new DateTime(2025, 9, 3, 1, 0, 0), Status = FlightStatus.InFlight, AircraftId = 4, RouteId = 5 },
                            new Flight { FlightNumber = "OA1500", DepartureUtc = new DateTime(2025, 9, 4, 23, 0, 0), ArrivalUtc = new DateTime(2025, 9, 4, 2, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 5, RouteId = 6 },
                            new Flight { FlightNumber = "PA1600", DepartureUtc = new DateTime(2025, 9, 5, 0, 0, 0), ArrivalUtc = new DateTime(2025, 9, 5, 3, 0, 0), Status = FlightStatus.Landed, AircraftId = 6, RouteId = 7 },
                            new Flight { FlightNumber = "QA1700", DepartureUtc = new DateTime(2025, 9, 6, 1, 0, 0), ArrivalUtc = new DateTime(2025, 9, 6, 4, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
                            new Flight { FlightNumber = "RA1800", DepartureUtc = new DateTime(2025, 9, 7, 2, 0, 0), ArrivalUtc = new DateTime(2025, 9, 7, 5, 0, 0), Status = FlightStatus.Delayed, AircraftId = 8, RouteId = 9 },
                            new Flight { FlightNumber = "SA1900", DepartureUtc = new DateTime(2025, 9, 8, 3, 0, 0), ArrivalUtc = new DateTime(2025, 9, 8, 6, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
                            new Flight { FlightNumber = "TA2000", DepartureUtc = new DateTime(2025, 9, 9, 4, 0, 0), ArrivalUtc = new DateTime(2025, 9, 9, 7, 0, 0), Status = FlightStatus.InFlight, AircraftId = 10, RouteId = 1 },
                            new Flight { FlightNumber = "UA2100", DepartureUtc = new DateTime(2025, 9, 10, 5, 0, 0), ArrivalUtc = new DateTime(2025, 9, 10, 8, 0, 0), Status = FlightStatus.Landed, AircraftId = 1, RouteId = 2 },
                            new Flight { FlightNumber = "VA2200", DepartureUtc = new DateTime(2025, 9, 11, 6, 0, 0), ArrivalUtc = new DateTime(2025, 9, 11, 9, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 2, RouteId = 3 },
                            new Flight { FlightNumber = "WA2300", DepartureUtc = new DateTime(2025, 9, 12, 7, 0, 0), ArrivalUtc = new DateTime(2025, 9, 12, 10, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 3, RouteId = 4 },
                            new Flight { FlightNumber = "XA2400", DepartureUtc = new DateTime(2025, 9, 13, 8, 0, 0), ArrivalUtc = new DateTime(2025, 9, 13, 11, 0, 0), Status = FlightStatus.Cancelled, AircraftId = 4, RouteId = 5 },
                            new Flight { FlightNumber = "YA2500", DepartureUtc = new DateTime(2025, 9, 14, 9, 0, 0), ArrivalUtc = new DateTime(2025, 9, 14, 12, 0, 0), Status = FlightStatus.Landed, AircraftId = 5, RouteId = 6 },
                            new Flight { FlightNumber = "ZA2600", DepartureUtc = new DateTime(2025, 9, 15, 10, 0, 0), ArrivalUtc = new DateTime(2025, 9, 15, 13, 0, 0), Status = FlightStatus.InFlight, AircraftId = 6, RouteId = 7 },
                            new Flight { FlightNumber = "AA2700", DepartureUtc = new DateTime(2025, 9, 16, 11, 0, 0), ArrivalUtc = new DateTime(2025, 9, 16, 14, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
                            new Flight { FlightNumber = "BA2800", DepartureUtc = new DateTime(2025, 9, 17, 12, 0, 0), ArrivalUtc = new DateTime(2025, 9, 17, 15, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 8, RouteId = 9 },
                            new Flight { FlightNumber = "CA2900", DepartureUtc = new DateTime(2025, 9, 18, 13, 0, 0), ArrivalUtc = new DateTime(2025, 9, 18, 16, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
                            new Flight { FlightNumber = "DA3000", DepartureUtc = new DateTime(2025, 9, 19, 14, 0, 0), ArrivalUtc = new DateTime(2025, 9, 19, 17, 0, 0), Status = FlightStatus.Cancelled, AircraftId = 10, RouteId = 1 }

                };
                foreach (var flight in flights)
                {
                    _flightRepository.Add(flight);
                }
            }


            //8. Flight Crew Member data creation
            if (!_flightCrewMemberRepository.GetAll().Any())
            {
                var flightCrewMembers = new List<CrewMember>
                    {
                        new CrewMember { FullName = "Salim Alsalami", Role = CrewRole.Pilot, LicenseNo = "12341" },
                        new CrewMember { FullName = "Ali Alsinani", Role = CrewRole.CoPilot, LicenseNo = "12322" },
                        new CrewMember { FullName = "Fatima Alharthy", Role = CrewRole.FlightAttendant, LicenseNo = "12333" },
                        new CrewMember { FullName = "Ahmed Alghamdi", Role = CrewRole.Pilot, LicenseNo = "12344" },
                        new CrewMember { FullName = "Sara Albalushi", Role = CrewRole.CoPilot, LicenseNo = "12355" },
                        new CrewMember { FullName = "Hassan Alhajri", Role = CrewRole.FlightAttendant, LicenseNo = "12366" },
                        new CrewMember { FullName = "Layla Alshamsi", Role = CrewRole.Pilot, LicenseNo = "12377" },
                        new CrewMember { FullName = "Omar Alharthy", Role = CrewRole.CoPilot, LicenseNo = "12388" },
                        new CrewMember { FullName = "Noura Alghamdi", Role = CrewRole.FlightAttendant, LicenseNo = "12399" },
                        new CrewMember { FullName = "Yusuf Albalushi", Role = CrewRole.Pilot, LicenseNo = "12400" },
                        new CrewMember { FullName = "Aisha Alhajri", Role = CrewRole.CoPilot, LicenseNo = "12411" },
                        new CrewMember { FullName = "Khalid Alshamsi", Role = CrewRole.FlightAttendant, LicenseNo = "12422" },
                        new CrewMember { FullName = "Zainab Alsalami", Role = CrewRole.Pilot, LicenseNo = "12433" },
                        new CrewMember { FullName = "Mohammed Alsinani", Role = CrewRole.CoPilot, LicenseNo = "12444" },
                        new CrewMember { FullName = "Fatimah Alharthy", Role = CrewRole.FlightAttendant, LicenseNo = "12455" },
                        new CrewMember { FullName = "Hamad Alghamdi", Role = CrewRole.Pilot, LicenseNo = "12466" },
                        new CrewMember { FullName = "Mariam Albalushi", Role = CrewRole.CoPilot, LicenseNo = "12477" },
                        new CrewMember { FullName = "Sultan Alhajri", Role = CrewRole.FlightAttendant, LicenseNo = "12488" },
                        new CrewMember { FullName = "Ranya Alshamsi", Role = CrewRole.Pilot, LicenseNo = "12499" },
                        new CrewMember { FullName = "Tariq Alsalami", Role = CrewRole.CoPilot, LicenseNo = "12500" },
                        new CrewMember { FullName = "Laila Alsinani", Role = CrewRole.FlightAttendant, LicenseNo = "12511" }
                    };
                foreach (var crewMember in flightCrewMembers)
                {
                    _flightCrewMemberRepository.Add(crewMember);
                }
            }
            //9. Flight Crew data creation
            if (!_flightCrewRepository.GetAll().Any())
                {
                    var flightCrews = new List<FlightCrew>
                    {
                        new FlightCrew { FlightId = 1, CrewId = 1, RoleOnFlight = "FlightAttendant" },
                        new FlightCrew { FlightId = 2, CrewId = 2, RoleOnFlight = "Pilot" },
                        new FlightCrew { FlightId = 3, CrewId = 3, RoleOnFlight = "CoPilot" },
                        new FlightCrew { FlightId = 4, CrewId = 4, RoleOnFlight = "FlightAttendant" },
                        new FlightCrew { FlightId = 5, CrewId = 5, RoleOnFlight = "Pilot" },
                        new FlightCrew { FlightId = 6, CrewId = 6, RoleOnFlight = "CoPilot" },
                        new FlightCrew { FlightId = 7, CrewId = 7, RoleOnFlight = "FlightAttendant" },
                        new FlightCrew { FlightId = 8, CrewId = 8, RoleOnFlight = "Pilot" },
                        new FlightCrew { FlightId = 9, CrewId = 9, RoleOnFlight = "CoPilot" },
                        new FlightCrew { FlightId = 10, CrewId = 10, RoleOnFlight = "FlightAttendant" },
                        new FlightCrew { FlightId = 11, CrewId = 1, RoleOnFlight = "Pilot" },
                        new FlightCrew { FlightId = 12, CrewId = 2, RoleOnFlight = "CoPilot" },
                        new FlightCrew { FlightId = 13, CrewId = 3, RoleOnFlight = "FlightAttendant" },
                        new FlightCrew { FlightId = 14, CrewId = 4, RoleOnFlight = "Pilot" },
                        new FlightCrew { FlightId = 15, CrewId = 5, RoleOnFlight = "CoPilot" }
                    };
                    foreach (var flightCrew in flightCrews)
                    {
                        _flightCrewRepository.Add(flightCrew);
                    }
                }

            //10. Ticket data creation
            if (!_ticketRepository.GetAll().Any())
            {
                var tickets = new List<Ticket>
                    {
                    new Ticket { SeatNumber = "1A", Fare = 500.00m, CheckedIn = true, BookingId = 1, FlightId = 1 },
                    new Ticket { SeatNumber = "1B", Fare = 600.00m, CheckedIn = false, BookingId = 2, FlightId = 2 },
                    new Ticket { SeatNumber = "1C", Fare = 550.00m, CheckedIn = true, BookingId = 3, FlightId = 3 },
                    new Ticket { SeatNumber = "1D", Fare = 700.00m, CheckedIn = false, BookingId = 4, FlightId = 4 },
                    new Ticket { SeatNumber = "1E", Fare = 650.00m, CheckedIn = true, BookingId = 5, FlightId = 5 },
                    new Ticket { SeatNumber = "1F", Fare = 800.00m, CheckedIn = false, BookingId = 6, FlightId = 6 },
                    new Ticket { SeatNumber = "2A", Fare = 520.00m, CheckedIn = true, BookingId = 7, FlightId = 7 },
                    new Ticket { SeatNumber = "2B", Fare = 620.00m, CheckedIn = false, BookingId = 8, FlightId = 8 },
                    new Ticket { SeatNumber = "2C", Fare = 570.00m, CheckedIn = true, BookingId = 9, FlightId = 9 },
                    new Ticket { SeatNumber = "2D", Fare = 720.00m, CheckedIn = false, BookingId = 10, FlightId = 10 },
                    new Ticket { SeatNumber = "3A", Fare = 530.00m, CheckedIn = true, BookingId = 1, FlightId = 11 },
                    new Ticket { SeatNumber = "3B", Fare = 630.00m, CheckedIn = false, BookingId = 2, FlightId = 12 },
                    new Ticket { SeatNumber = "3C", Fare = 580.00m, CheckedIn = true, BookingId = 3, FlightId = 13 },
                    new Ticket { SeatNumber = "3D", Fare = 730.00m, CheckedIn = false, BookingId = 4, FlightId = 14 },
                    new Ticket { SeatNumber = "3E", Fare = 680.00m, CheckedIn = true, BookingId = 5, FlightId = 15 },
                    new Ticket { SeatNumber = "3F", Fare = 830.00m, CheckedIn = false, BookingId = 6, FlightId = 16 },
                    new Ticket { SeatNumber = "4A", Fare = 540.00m, CheckedIn = true, BookingId = 7, FlightId = 17 },
                    new Ticket { SeatNumber = "4B", Fare = 640.00m, CheckedIn = false, BookingId = 8, FlightId = 18 },
                    new Ticket { SeatNumber = "4C", Fare = 590.00m, CheckedIn = true, BookingId = 9, FlightId = 19 },
                    new Ticket { SeatNumber = "4D", Fare = 740.00m, CheckedIn = false, BookingId = 10, FlightId = 20 }
                    };
                foreach (var ticket in tickets)
                {
                    _ticketRepository.Add(ticket);
                }
            }

            // Baggage data creation
            if (!_baggageRepository.GetAll().Any())
            {
                var baggages = new List<Baggage>
                {
                    new Baggage { WeightKg = 20, TagNumber = "TAG001"  , TicketId = 1},
                    new Baggage { WeightKg = 25, TagNumber = "TAG002", TicketId = 2 },
                    new Baggage { WeightKg = 15, TagNumber = "TAG003", TicketId = 3 },
                    new Baggage { WeightKg = 30, TagNumber = "TAG004", TicketId = 4 },
                    new Baggage { WeightKg = 22, TagNumber = "TAG005", TicketId = 5 },
                    new Baggage { WeightKg = 18, TagNumber = "TAG006", TicketId = 6 },
                    new Baggage { WeightKg = 28, TagNumber = "TAG007", TicketId = 7 },
                    new Baggage { WeightKg = 24, TagNumber = "TAG008", TicketId = 8 },
                    new Baggage { WeightKg = 19, TagNumber = "TAG009", TicketId = 9 }
                };
                foreach (var baggage in baggages)
                {
                    _baggageRepository.Add(baggage);
                }
            }















        }




    }

}
