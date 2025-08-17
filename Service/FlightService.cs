using FlightManagementCompany.Data;
using FlightManagementCompany.DTO;
using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
                        new Aircraft { TailNumber = "N12345", Model = "Boeing 777", Capacity = 396 },
                        new Aircraft { TailNumber = "N67890", Model = "Airbus A380", Capacity = 555 },
                        new Aircraft { TailNumber = "N54321", Model = "Boeing 737", Capacity = 189 },
                        new Aircraft { TailNumber = "N09876", Model = "Airbus A320", Capacity = 180 },
                        new Aircraft { TailNumber = "N11223", Model = "Boeing 787", Capacity = 242 },
                        new Aircraft { TailNumber = "N44556", Model = "Airbus A350", Capacity = 440 },
                        new Aircraft { TailNumber = "N77889", Model = "Boeing 747", Capacity = 660 },
                        new Aircraft { TailNumber = "N99001", Model = "Airbus A330", Capacity = 277 },
                        new Aircraft { TailNumber = "N22334", Model = "Boeing 767", Capacity = 216 },
                        new Aircraft { TailNumber = "N55667", Model = "Airbus A220", Capacity = 120 },
                        new Aircraft { TailNumber = "N88990", Model = "Boeing 737 MAX", Capacity = 210 },
                        new Aircraft { TailNumber = "N11234", Model = "Airbus A321", Capacity = 220 },
                        new Aircraft { TailNumber = "N44567", Model = "Boeing 757", Capacity = 200 },
                        new Aircraft { TailNumber = "N77890", Model = "Airbus A319", Capacity = 150 },
                        new Aircraft { TailNumber = "N99012", Model = "Boeing 767-300", Capacity = 218 },
                        new Aircraft { TailNumber = "N22345", Model = "Airbus A310", Capacity = 280 },
                        new Aircraft { TailNumber = "N55678", Model = "Boeing 787-9", Capacity = 296 },
                        new Aircraft { TailNumber = "N88901", Model = "Airbus A350-900", Capacity = 440 },
                        new Aircraft { TailNumber = "N11256", Model = "Boeing 777-300ER", Capacity = 550 },
                        new Aircraft { TailNumber = "N44589", Model = "Airbus A330-300", Capacity = 277 }
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
            //4. Passenger data creation
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
            //5. Booking data creation
            if (!_bookingRepository.GetAll().Any())
            {
                var bookings = new List<Booking>
                {
                    new Booking { BookingRef = "BK0001", BookingDate = new DateTime(2025, 8, 20), Status = BookingStatus.Confirmed, PassengerId = 1 },
                    new Booking { BookingRef = "BK0002", BookingDate = new DateTime(2025, 8, 21), Status = BookingStatus.Cancelled, PassengerId = 2 },
                    new Booking { BookingRef = "BK0003", BookingDate = new DateTime(2025, 8, 22), Status = BookingStatus.Confirmed, PassengerId = 3 },
                    new Booking { BookingRef = "BK0004", BookingDate = new DateTime(2025, 8, 23), Status = BookingStatus.Pending, PassengerId = 4 },
                    new Booking { BookingRef = "BK0005", BookingDate = new DateTime(2025, 8, 24), Status = BookingStatus.Confirmed, PassengerId = 5 },
                    new Booking { BookingRef = "BK0006", BookingDate = new DateTime(2025, 8, 25), Status = BookingStatus.Cancelled, PassengerId = 6 },
                    new Booking { BookingRef = "BK0007", BookingDate = new DateTime(2025, 8, 26), Status = BookingStatus.Confirmed, PassengerId = 7 },
                    new Booking { BookingRef = "BK0008", BookingDate = new DateTime(2025, 8, 27), Status = BookingStatus.Pending, PassengerId = 8 },
                    new Booking { BookingRef = "BK0009", BookingDate = new DateTime(2025, 8, 28), Status = BookingStatus.Confirmed, PassengerId = 9 },
                    new Booking { BookingRef = "BK0010", BookingDate = new DateTime(2025, 8, 29), Status = BookingStatus.Cancelled, PassengerId = 10 }
                };
                foreach (var booking in bookings)
                {
                    _bookingRepository.Add(booking);
                }
            }




            //6. Aircraft Maintenance data creation
            if (!_aircraftMaintenanceRepository.GetAll().Any())
            {
                var aircraftMaintenances = new List<AircraftMaintenance>
                    {
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 20), Type = "Engine Inspection", Notes = "Engine check", AircraftId = 14 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 21), Type = "Tire Replacement", Notes = "Replaced front tires", AircraftId = 12 },
                        new AircraftMaintenance { MaintenanceDate = new DateTime(2025, 8, 22), Type = "Fuel System Check", Notes = "Checked fuel lines", AircraftId = 15 },
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
                            new Flight { FlightNumber = "AA100", DepartureUtc = new DateTime(2025, 8, 21, 9, 0, 0), ArrivalUtc = new DateTime(2025, 8, 21, 12, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 4, RouteId = 2 },
                            new Flight { FlightNumber = "BA200", DepartureUtc = new DateTime(2025, 8, 22, 10, 0, 0), ArrivalUtc = new DateTime(2025, 8, 22, 13, 0, 0), Status = FlightStatus.InFlight, AircraftId = 5, RouteId = 3 },
                            new Flight { FlightNumber = "CA300", DepartureUtc = new DateTime(2025, 8, 23, 11, 0, 0), ArrivalUtc = new DateTime(2025, 8, 23, 14, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 6, RouteId = 4 },
                            new Flight { FlightNumber = "DA400", DepartureUtc = new DateTime(2025, 8, 24, 12, 0, 0), ArrivalUtc = new DateTime(2025, 8, 24, 15, 0, 0), Status = FlightStatus.Landed, AircraftId = 4, RouteId = 5 },
                            new Flight { FlightNumber = "EA500", DepartureUtc = new DateTime(2025, 8, 25, 13, 0, 0), ArrivalUtc = new DateTime(2025, 8, 25, 16, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 5, RouteId = 6 },
                            new Flight { FlightNumber = "FA600", DepartureUtc = new DateTime(2025, 8, 26, 14, 0, 0), ArrivalUtc = new DateTime(2025, 8, 26, 17, 0, 0), Status = FlightStatus.InFlight, AircraftId = 6, RouteId = 7 },
                            new Flight { FlightNumber = "GA700", DepartureUtc = new DateTime(2025, 8, 27, 15, 0, 0), ArrivalUtc = new DateTime(2025, 8, 27, 18, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
                            new Flight { FlightNumber = "HA800", DepartureUtc = new DateTime(2025, 8, 28, 16, 0, 0), ArrivalUtc = new DateTime(2025, 8, 28, 19, 0, 0), Status = FlightStatus.Landed, AircraftId = 8, RouteId = 9 },
                            new Flight { FlightNumber = "IA900", DepartureUtc = new DateTime(2025, 8, 29, 17, 0, 0), ArrivalUtc = new DateTime(2025, 8, 29, 20, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
                            new Flight { FlightNumber = "JA1000", DepartureUtc = new DateTime(2025, 8, 30, 18, 0, 0), ArrivalUtc = new DateTime(2025, 8, 30, 21, 0, 0), Status = FlightStatus.InFlight, AircraftId = 10, RouteId = 1 },
                            new Flight { FlightNumber = "KA1100", DepartureUtc = new DateTime(2025, 8, 31, 19, 0, 0), ArrivalUtc = new DateTime(2025, 8, 31, 22, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 12, RouteId = 2 },
                            new Flight { FlightNumber = "LA1200", DepartureUtc = new DateTime(2025, 9, 1, 20, 0, 0), ArrivalUtc = new DateTime(2025, 9, 1, 23, 0, 0), Status = FlightStatus.Landed, AircraftId = 12, RouteId = 3 },
                            new Flight { FlightNumber = "MA1300", DepartureUtc = new DateTime(2025, 9, 2, 21, 0, 0), ArrivalUtc = new DateTime(2025, 9, 2, 0, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 13, RouteId = 4 },
                            new Flight { FlightNumber = "NA1400", DepartureUtc = new DateTime(2025, 9, 3, 22, 0, 0), ArrivalUtc = new DateTime(2025, 9, 3, 1, 0, 0), Status = FlightStatus.InFlight, AircraftId = 4, RouteId = 5 },
                            new Flight { FlightNumber = "OA1500", DepartureUtc = new DateTime(2025, 9, 4, 23, 0, 0), ArrivalUtc = new DateTime(2025, 9, 4, 2, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 5, RouteId = 6 },
                            new Flight { FlightNumber = "PA1600", DepartureUtc = new DateTime(2025, 9, 5, 0, 0, 0), ArrivalUtc = new DateTime(2025, 9, 5, 3, 0, 0), Status = FlightStatus.Landed, AircraftId = 6, RouteId = 7 },
                            new Flight { FlightNumber = "QA1700", DepartureUtc = new DateTime(2025, 9, 6, 1, 0, 0), ArrivalUtc = new DateTime(2025, 9, 6, 4, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 7, RouteId = 8 },
                            new Flight { FlightNumber = "RA1800", DepartureUtc = new DateTime(2025, 9, 7, 2, 0, 0), ArrivalUtc = new DateTime(2025, 9, 7, 5, 0, 0), Status = FlightStatus.Delayed, AircraftId = 8, RouteId = 9 },
                            new Flight { FlightNumber = "SA1900", DepartureUtc = new DateTime(2025, 9, 8, 3, 0, 0), ArrivalUtc = new DateTime(2025, 9, 8, 6, 0, 0), Status = FlightStatus.Scheduled, AircraftId = 9, RouteId = 10 },
                            new Flight { FlightNumber = "TA2000", DepartureUtc = new DateTime(2025, 9, 9, 4, 0, 0), ArrivalUtc = new DateTime(2025, 9, 9, 7, 0, 0), Status = FlightStatus.InFlight, AircraftId = 10, RouteId = 1 },
                            new Flight { FlightNumber = "UA2100", DepartureUtc = new DateTime(2025, 9, 10, 5, 0, 0), ArrivalUtc = new DateTime(2025, 9, 10, 8, 0, 0), Status = FlightStatus.Landed, AircraftId = 11, RouteId = 2 },
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

            //8. Crew Member data creation
            if (!_flightCrewMemberRepository.GetAll().Any())
            {
                var crewMembers = new List<CrewMember>
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
                foreach (var crewMember in crewMembers)
                {
                    _flightCrewMemberRepository.Add(crewMember);
                }
            }



            //9. Flight Crew data creation
            if (!_flightCrewRepository.GetAll().Any())
            {
                var flightCrews = new List<FlightCrew>
                    {
                        new FlightCrew { FlightId = 19, CrewId = 1, RoleOnFlight = "FlightAttendant" },
                        new FlightCrew { FlightId = 18, CrewId = 2, RoleOnFlight = "Pilot" },
                        new FlightCrew { FlightId = 17, CrewId = 3, RoleOnFlight = "CoPilot" },
                        new FlightCrew { FlightId = 16, CrewId = 4, RoleOnFlight = "FlightAttendant" },
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
                    new Ticket { SeatNumber = "1B", Fare = 600.00m, CheckedIn = false, BookingId = 2, FlightId = 22 },
                    new Ticket { SeatNumber = "1C", Fare = 550.00m, CheckedIn = true, BookingId = 3, FlightId = 1 },
                    new Ticket { SeatNumber = "1D", Fare = 700.00m, CheckedIn = false, BookingId = 4, FlightId = 24 },
                    new Ticket { SeatNumber = "1E", Fare = 650.00m, CheckedIn = true, BookingId = 5, FlightId = 1 },
                    new Ticket { SeatNumber = "1F", Fare = 800.00m, CheckedIn = false, BookingId = 6, FlightId = 26 },
                    new Ticket { SeatNumber = "2A", Fare = 520.00m, CheckedIn = true, BookingId = 7, FlightId = 27 },
                    new Ticket { SeatNumber = "2B", Fare = 620.00m, CheckedIn = false, BookingId = 8, FlightId = 1 },
                    new Ticket { SeatNumber = "2C", Fare = 570.00m, CheckedIn = true, BookingId = 1, FlightId = 29 },
                    new Ticket { SeatNumber = "2D", Fare = 720.00m, CheckedIn = false, BookingId = 2, FlightId = 10 },
                    new Ticket { SeatNumber = "3A", Fare = 530.00m, CheckedIn = true, BookingId = 8, FlightId = 11 },
                    new Ticket { SeatNumber = "3B", Fare = 630.00m, CheckedIn = false, BookingId = 2, FlightId = 12 },
                    new Ticket { SeatNumber = "3C", Fare = 580.00m, CheckedIn = true, BookingId = 3, FlightId = 13 },
                    new Ticket { SeatNumber = "3D", Fare = 730.00m, CheckedIn = false, BookingId = 4, FlightId = 14 },
                    new Ticket { SeatNumber = "3E", Fare = 680.00m, CheckedIn = true, BookingId = 5, FlightId = 15 },
                    new Ticket { SeatNumber = "3F", Fare = 830.00m, CheckedIn = false, BookingId = 6, FlightId = 16 },
                    new Ticket { SeatNumber = "4A", Fare = 540.00m, CheckedIn = true, BookingId = 7, FlightId = 17 },
                    new Ticket { SeatNumber = "4B", Fare = 640.00m, CheckedIn = false, BookingId = 8, FlightId = 18 },
                    new Ticket { SeatNumber = "4C", Fare = 590.00m, CheckedIn = true, BookingId = 1, FlightId = 19 },
                    new Ticket { SeatNumber = "4D", Fare = 740.00m, CheckedIn = false, BookingId = 2, FlightId = 20 }
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
                    new Baggage { WeightKg = 20, TagNumber = "TAG001" , TicketId = 10},
                    new Baggage { WeightKg = 25, TagNumber = "TAG002", TicketId = 12 },
                    new Baggage { WeightKg = 15, TagNumber = "TAG003", TicketId = 13 },
                    new Baggage { WeightKg = 30, TagNumber = "TAG004", TicketId = 14 },
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

        //1. Daily Flight Manifest 
        public List<FlightManifestDto> GetDailyFlightManifest(DateTime dateUtc)
        {
            var start = dateUtc.Date;
            var end = start.AddDays(1);

            var flights = _flightRepository.GetAll()?
                .Where(f => f.DepartureUtc >= start && f.DepartureUtc < end)
                .ToList() ?? new List<Flight>();

            if (flights.Count == 0) return new List<FlightManifestDto>();

            // Prefetch once (simple + avoids repeated repo calls)
            var tickets = _ticketRepository.GetAll()?.ToList() ?? new List<Ticket>();
            var baggages = _baggageRepository.GetAll()?.ToList() ?? new List<Baggage>();
            var crews = _flightCrewRepository.GetAll()?.ToList() ?? new List<FlightCrew>();

            var result = new List<FlightManifestDto>();

            // For fast baggage lookup
            var baggageByTicketId = baggages.GroupBy(b => b.TicketId)
                                            .ToDictionary(g => g.Key, g => g.Sum(x => x.WeightKg));

            foreach (var f in flights)
            {
                // Origin/Destination via route+airport IDs
                string origin = "N/A", dest = "N/A", tail = "N/A";

                if (f.RouteId > 0)
                {
                    var route = _routeRepository.GetById(f.RouteId);
                    if (route != null)
                    {
                        var o = _airportRepository.GetById(route.OriginAirportId);
                        var d = _airportRepository.GetById(route.DestinationAirportId);
                        origin = o?.IATA ?? "N/A";
                        dest = d?.IATA ?? "N/A";
                    }
                }

                if (f.AircraftId > 0)
                {
                    var ac = _aircraftRepository.GetById(f.AircraftId);
                    tail = ac?.TailNumber ?? "N/A";
                }

                var flightTickets = tickets.Where(t => t.FlightId == f.FlightId).ToList();
                int passengerCount = flightTickets.Count;

                decimal totalBaggageKg = 0;
                if (passengerCount > 0)
                {
                    foreach (var t in flightTickets)
                        totalBaggageKg += baggageByTicketId.TryGetValue(t.TicketId, out var kg) ? kg : 0;
                }

                var flightCrews = crews.Where(c => c.FlightId == f.FlightId).ToList();
                var crewDtos = flightCrews.Select(c => new CrewDto
                {
                    Name = c.CrewMember?.FullName ?? "N/A",
                    Role = c.RoleOnFlight ?? "N/A"
                }).ToList();

                result.Add(new FlightManifestDto
                {
                    FlightId = f.FlightId,
                    FlightNumber = f.FlightNumber,
                    DepUtc = f.DepartureUtc,
                    ArrUtc = f.ArrivalUtc,
                    Origin = origin,
                    Destination = dest,
                    AircraftTail = tail,
                    PassengerCount = passengerCount,
                    TotalBaggageKg = totalBaggageKg,
                    Crew = crewDtos
                });
            }

            return result;
        }
        //2. Top Routes by Revenue

        public IEnumerable<RouteRevenueDto> GetRouteRevenue(DateTime startDate, DateTime endDate)
        {
            // Normalize to [start, end) — end exclusive
            var start = startDate.Date;
            var end = endDate.Date.AddDays(1);

            // 1) Pull flights in the window
            var flights = _flightRepository.GetFlightsByDateRange(start, end) ?? Enumerable.Empty<Flight>();
            var flightIds = flights.Select(f => f.FlightId).ToHashSet();

            if (flightIds.Count == 0) return Enumerable.Empty<RouteRevenueDto>();

            // 2) Pull tickets once and filter by those flights
            var tickets = _ticketRepository.GetAll() ?? Enumerable.Empty<Ticket>();
            var ticketsInRange = tickets.Where(t => flightIds.Contains(t.FlightId) && t.Fare != null).ToList();
            if (ticketsInRange.Count == 0) return Enumerable.Empty<RouteRevenueDto>();

            // 3) Build a lookup FlightId -> RouteId
            var flightToRoute = flights
                .Where(f => f.RouteId > 0)
                .ToDictionary(f => f.FlightId, f => f.RouteId); 

            // 4) Pull all routes (or a targeted call per needed RouteId if you prefer)
            //    To stay simple and efficient, fetch just the needed routes:
            var routeIds = flightToRoute.Values.Distinct().ToList();
            var routes = routeIds.Select(rid => _routeRepository.GetById(rid))
                                 .Where(r => r != null)
                                 .ToDictionary(r => r.RouteId);

            // 5) For airport codes, fetch by ID on demand (cache results)
            var airportCache = new Dictionary<int, Airport>();
            string Iata(int airportId)
            {
                if (airportId <= 0) return "N/A";
                if (!airportCache.TryGetValue(airportId, out var ap))
                {
                    ap = _airportRepository.GetById(airportId);
                    if (ap != null) airportCache[airportId] = ap;
                }
                return ap?.IATA ?? "N/A";
            }

  

            var query =
               from t in ticketsInRange
               where flightToRoute.ContainsKey(t.FlightId)
               let routeId = flightToRoute[t.FlightId]
               where routes.ContainsKey(routeId)
               let route = routes[routeId]
               select new
               {
                   RouteId = route.RouteId,
                   Origin = Iata(route.OriginAirportId),
                   Dest = Iata(route.DestinationAirportId),

                   Fare = t.Fare != null ? t.Fare : 0m // Ensure Fare is not null by explicitly checking
               };

            var grouped = query
                .GroupBy(x => new { x.RouteId, x.Origin, x.Dest })
                .Select(g => new RouteRevenueDto
                {
                    RouteId = g.Key.RouteId,
                    Origin = g.Key.Origin,
                    Destination = g.Key.Dest,
                    Revenue = g.Sum(x => x.Fare),
                    SeatsSold = g.Count(),
                    AvgFare = g.Average(x => x.Fare)
                })
                .OrderByDescending(r => r.Revenue)
                .ToList();

            return grouped;
        }




        //3. On-Time Performance 
        public OnTimePerformanceDto GetOnTimePerformance(DateTime startDate, DateTime endDate)
        {
            var flights = _flightRepository.GetAll()
                .Where(f => f.DepartureUtc.Date >= startDate.Date &&
                            f.DepartureUtc.Date <= endDate.Date)
                .ToList();

            if (!flights.Any())
                return new OnTimePerformanceDto(); // return empty DTO if no flights found

            var totalFlights = flights.Count;

            // counting "on-time" flights as Landed without delay, or still Scheduled
            var onTimeFlights = flights.Count(f =>
                f.Status == FlightStatus.Landed || f.Status == FlightStatus.Scheduled);

            var delayedFlights = totalFlights - onTimeFlights;

            return new OnTimePerformanceDto
            {
                TotalFlights = totalFlights,
                OnTimeFlights = onTimeFlights,
                DelayedFlights = delayedFlights,
                OnTimePercentage = (double)onTimeFlights / totalFlights * 100
            };
        }


        //4. Seat Occupancy Heatmap
        public List<SeatOccupancyDto> GetSeatOccupancyHeatmap(DateTime startDate, DateTime endDate)
        {
            var start = startDate.Date;
            var endEx = endDate.Date.AddDays(1); // end exclusive

            // Flights in range
            var flights = _flightRepository.GetFlightsByDateRange(start, endEx) ?? Enumerable.Empty<Flight>();
            var flightsById = flights.ToDictionary(f => f.FlightId, f => f);
            if (flightsById.Count == 0) return new List<SeatOccupancyDto>();

            // Build FlightId -> AircraftTail map
            var tailByFlightId = new Dictionary<int, string>();
            foreach (var f in flights)
            {
                string tail = "Unknown";
                if (f.AircraftId > 0)
                {
                    var ac = _aircraftRepository.GetById(f.AircraftId);
                    if (ac != null && !string.IsNullOrWhiteSpace(ac.TailNumber))
                        tail = ac.TailNumber;
                }
                tailByFlightId[f.FlightId] = tail;
            }

            // Tickets (all), then keep only those whose FlightId is in range
            var tickets = _ticketRepository.GetAll() ?? Enumerable.Empty<Ticket>();

            var grouped = tickets
                .Where(t => t != null
                            && !string.IsNullOrWhiteSpace(t.SeatNumber)
                            && tailByFlightId.ContainsKey(t.FlightId)) // ensures flight in date window
                .GroupBy(t => new
                {
                    Tail = tailByFlightId[t.FlightId],
                    Seat = t.SeatNumber!
                })
                .Select(g => new SeatOccupancyDto
                {
                    AircraftTail = g.Key.Tail,
                    SeatNumber = g.Key.Seat,
                    TimesOccupied = g.Count()
                })
                .OrderByDescending(x => x.TimesOccupied)
                .ThenBy(x => x.AircraftTail)
                .ThenBy(x => x.SeatNumber)
                .ToList();

            return grouped;
        }


        // 5. Find Available Seats for a Flight
        //public IEnumerable<string> GetAvailableSeatsForFlight(int flightId)
        //{
        //var flight = _flightRepository.GetById(flightId); // get flight by ID  
        //if (flight == null) return Enumerable.Empty<string>(); // return empty if flight not found  

        ////return availableSeats; // return the list of available seats  
        //var capacity = flight.Aircraft.Capacity; // get aircraft capacity
        //// check if capacity is valid
        //if (capacity <= 0) return Enumerable.Empty<string>(); // return empty if capacity is invalid
        //var seatMap = BuildSeatMap(capacity); // get aircraft seat map


        //var bookedSeats = _ticketRepository.GetAll() // get all tickets from the repository
        //    .Where(t => t.FlightId == flightId) // filter tickets by flight ID
        //    .Select(t => t.SeatNumber) // select booked seat numbers
        //    .ToList(); // convert to list

        //var availableSeats = seatMap // use the seat map to generate seat numbers
        //    .Where(seat => !bookedSeats.Contains(seat)) // filter out booked seats
        //    .ToList(); // convert to list


        ////return availableSeats; // return the list of available seats
        //var flight = _flightRepository.GetById(flightId); // get flight by ID
        //if (flight == null) return Enumerable.Empty<string>(); // return empty if flight not found
        //var capacity = flight.Aircraft.Capacity; // get aircraft capacity
        //// check if capacity is valid
        //if (capacity <= 0) return Enumerable.Empty<string>(); // return empty if capacity is invalid
        //var seatMap = BuildSeatMap(capacity); // get aircraft seat map
        //var bookedSeats = _ticketRepository.GetAll() // get all tickets from the repository
        //    .Where(t => t.FlightId == flightId) // filter tickets by flight ID
        //    .Select(t => t.SeatNumber) // select booked seat numbers
        //    .ToList(); // convert to list
        //var availableSeats = seatMap // use the seat map to generate seat numbers
        //    .Where(seat => !bookedSeats.Contains(seat)) // filter out booked seats
        //    .ToList(); // convert to list
        //return availableSeats; // return the list of available seats
        //}
        //public IEnumerable<string> GetAvailableSeatsForFlight(int flightId)
        //{
        //    var flight = _flightRepository.GetById(flightId);

        //    if (flight == null || flight.Aircraft == null)
        //        return Enumerable.Empty<string>();

        //    var bookedSeats = flight.Tickets?.Select(t => t.SeatNumber) ?? Enumerable.Empty<string>();
        //    var allSeats = Enumerable.Range(1, flight.Aircraft.Capacity).Select(n => n.ToString());

        //    return allSeats.Except(bookedSeats); // return all seats that are not booked
        //}



        public IEnumerable<string> GetAvailableSeatsForFlight(int flightId)
        {
            var flight = _flightRepository.GetById(flightId);

            if (flight == null || flight.Aircraft == null)
                return Enumerable.Empty<string>();

            var seatMap = BuildSeatMap(flight.Aircraft.Capacity);

            var bookedSeats = _ticketRepository.GetAll()
                .Where(t => t.FlightId == flightId)
                .Select(t => t.SeatNumber)
                .ToList();

            return seatMap.Where(seat => !bookedSeats.Contains(seat));

        }









        //6. Crew Scheduling Conflicts

        public List<CrewConflictDto> GetCrewSchedulingConflicts()
        {
            var flightsWithCrew = _flightRepository.GetAll()
         .Select(f => new
         {
             FlightId = f.FlightId,
             DepartureUtc = f.DepartureUtc,
             ArrivalUtc = f.ArrivalUtc,
             Crew = (f.FlightCrew ?? new List<FlightCrew>())
                     .Where(fc => fc != null && fc.CrewMember != null)
                     .Select(fc => new
                     {
                         CrewId = fc.CrewMember.CrewId,
                         FullName = fc.CrewMember.FullName,
                         LicenseNo = fc.CrewMember.LicenseNo
                     })
                     .ToList()
         })
         // ignore flights that have no crew after null-safety filtering
         .Where(f => f.Crew.Count > 0)
         .ToList();

            var conflicts = new List<CrewConflictDto>();

            // Compare flights pairwise (simple and clear). 
            // If your dates can be nullable, add HasValue checks here.
            foreach (var a in flightsWithCrew)
            {
                foreach (var b in flightsWithCrew.Where(f => f.FlightId > a.FlightId))
                {
                    bool overlaps = a.DepartureUtc < b.ArrivalUtc &&
                                    b.DepartureUtc < a.ArrivalUtc;

                    if (!overlaps) continue;

                    var overlappingCrew = a.Crew
                        .Join(b.Crew, ca => ca.CrewId, cb => cb.CrewId,
                              (ca, cb) => new { ca.CrewId, ca.FullName })
                        .ToList();

                    foreach (var c in overlappingCrew)
                    {
                        conflicts.Add(new CrewConflictDto
                        {
                            CrewId = c.CrewId,
                            CrewName = c.FullName,
                            FlightAId = a.FlightId,
                            FlightBId = b.FlightId,
                            FlightADep = a.DepartureUtc,
                            FlightBDep = b.DepartureUtc
                        });
                    }
                }
            }

            return conflicts;
        }


        //7. Passengers with Connections
        public List<PassengerConnectionDto> GetPassengersWithConnections(double maxHoursBetween)
        {
            var passengers = _passengerRepository.GetAll()
                // Only keep passengers who have at least one booking with at least 2 tickets (null-safe)
                .Where(p => (p.Bookings ?? new List<Booking>())
                                .Any(b => (b.Tickets ?? new List<Ticket>()).Count >= 2))
                .Select(p => new PassengerConnectionDto
                {
                    PassengerId = p.PassengerId,
                    Name = p.FullName,

                    ConnectingFlights = (p.Bookings ?? new List<Booking>())
                        .SelectMany(b =>
                        {
                            // Order tickets by the *flight* departure time (null-safe)
                            var ordered = (b.Tickets ?? new List<Ticket>())
                                .Where(t =>
                                       t.Flight != null &&
                                       t.Flight.DepartureUtc != default &&
                                       t.Flight.ArrivalUtc != default)
                                .OrderBy(t => t.Flight.DepartureUtc)
                                .ToList();

                            // Pair consecutive tickets and compute layover between flights
                            return ordered.Zip(ordered.Skip(1), (prev, next) => new
                            {
                                Prev = prev,
                                Next = next,
                                GapHours = (next.Flight.DepartureUtc - prev.Flight.ArrivalUtc).TotalHours
                            })
                            .Where(x => x.GapHours >= 0 && x.GapHours <= maxHoursBetween)
                            .Select(x => new FlightBookingDto
                            {
                                // You previously showed the "next flight" details in the leg; keeping that.
                                FlightId = x.Next.FlightId,
                                FlightNumber = x.Next.Flight?.FlightNumber ?? "N/A",
                                DepartureAirport = x.Next.Flight?.Route?.OriginAirport?.IATA ?? "N/A",
                                ArrivalAirport = x.Next.Flight?.Route?.DestinationAirport?.IATA ?? "N/A",
                                DepartureTime = x.Next.Flight?.DepartureUtc ?? default,
                                ArrivalTime = x.Next.Flight?.ArrivalUtc ?? default,
                                SeatNumber = x.Next.SeatNumber,
                                // Optional: if your DTO has room, you can add LayoverHours = x.GapHours
                            });
                        })
                        .ToList()
                })
                .Where(p => p.ConnectingFlights != null && p.ConnectingFlights.Any())
                .OrderBy(p => p.Name)
                .ToList();

            return passengers;
        }






        //8. Frequent Flyer Stats
        public List<FrequentFlyerDto> GetFrequentFlyerStats(DateTime startDate, DateTime endDate)
        {
            var stats = _ticketRepository.GetAll() // get all tickets from the repository
                .Where(t => t.Flight.DepartureUtc.Date >= startDate.Date &&
                            t.Flight.DepartureUtc.Date <= endDate.Date) // filter tickets by flight date range
                .GroupBy(t => new // group by PassengerId and FullName
                {
                    t.Booking.Passenger.PassengerId, // get Passenger ID
                    t.Booking.Passenger.FullName // get Passenger Full Name
                })
                .Select(g => new FrequentFlyerDto // class to hold frequent flyer statistics
                {
                    PassengerId = g.Key.PassengerId, // get Passenger ID -- Key is anonymous type with PassengerId and FullName (grouping key)
                    PassengerName = g.Key.FullName, // get Passenger Full Name
                    FlightsTaken = g.Select(t => t.FlightId).Distinct().Count() // Removes duplicates and counts unique flights taken by the passenger
                                                                                // g itself is an enumeration of all Ticket rows that belong to that passenger for the filtered date range.
                })
                .OrderByDescending(f => f.FlightsTaken) // order by number of flights taken descending
                .ToList(); // execute the query and get the results in a list

            return stats; // return the list of frequent flyer statistics
        }


        // 9. Maintanance Alert
        public List<MaintenanceAlertDto> GetMaintenanceAlerts()
        {
            const int maintenanceThresholdDays = 30;
            var thresholdDate = DateTime.UtcNow.AddDays(-maintenanceThresholdDays);

            var alerts = _aircraftRepository.GetAll()
                .Where(a => a.AircraftMaintenances.Any())
                .Select(a => new
                {
                    Aircraft = a,
                    LastMaintenance = a.AircraftMaintenances
                                     .OrderByDescending(m => m.MaintenanceDate)
                                     .FirstOrDefault(),
                    LatestFlight = a.Flights.OrderByDescending(f => f.DepartureUtc).FirstOrDefault()
                })
                .Select(x => new MaintenanceAlertDto
                {
                    FlightId = x.LatestFlight?.FlightId ?? 0,
                    FlightNumber = x.LatestFlight?.FlightNumber ?? "N/A",
                    AircraftTail = x.Aircraft.TailNumber,
                    LastMaintenanceDate = x.LastMaintenance?.MaintenanceDate ?? DateTime.MinValue,
                    NextMaintenanceDueDate = (DateTime)(x.LastMaintenance != null? x.LastMaintenance.MaintenanceDate.AddDays(maintenanceThresholdDays): (DateTime?)null),
                    IsDueForMaintenance = x.LastMaintenance == null ||
                                         x.LastMaintenance.MaintenanceDate < thresholdDate
                })
                .Where(a => a.IsDueForMaintenance)
                .ToList();

            return alerts;
        }


        //10. Baggage Overweight Alerts
        //Tickets whose total baggage weight exceeds threshold(e.g., 30kg per passenger). Use GroupBy ticket and sum baggage weights.

        public List<BaggageOverweightDto> GetBaggageOverweightAlerts(decimal weightThreshold)
        {
            var alerts = _ticketRepository.GetAll() // get all tickets from the repository
                .Select(t => new // transform each ticket into a DTO
                {
                    TicketId = t.TicketId, // get Ticket ID
                    PassengerName = t.Booking.Passenger.FullName, // get Passenger Full Name
                    TotalBaggageWeight = t.Baggages.Sum(b => b.WeightKg) // sum of baggage weights for the ticket
                })
                .Where(t => t.TotalBaggageWeight > weightThreshold) // filter tickets with total baggage weight exceeding threshold
                .Select(t => new BaggageOverweightDto // class to hold baggage overweight details
                {
                    TicketId = t.TicketId, // get Ticket ID
                    PassengerName = t.PassengerName, // get Passenger Full Name
                    TotalBaggageWeight = (double)t.TotalBaggageWeight // get total baggage weight
                })
                .ToList(); // execute the query and get the results in a list
            return alerts; // return the list of baggage overweight alerts
        }



        
        // 11. Complex Set/Partitioning Examples
        //public List<PassengerDto> GetCombinedPassengerList()
        //{
        //    var vipPassengers = _passengerRepository.GetAll() // get all VIP passengers
        //        .Where(p => p.IsVip) // filter VIP passengers
        //        .Select(p => new PassengerDto // class to hold passenger details
        //        {
        //            PassengerId = p.PassengerId, // get Passenger ID
        //            FullName = p.FullName // get Passenger Full Name
        //        });
        //    var frequentFlyers = _passengerRepository.GetAll() // get all frequent flyers
        //        .Where(p => p.FlightCount > 5) // filter frequent flyers with more than 5 flights
        //        .Select(p => new PassengerDto // class to hold passenger details
        //        {
        //            PassengerId = p.PassengerId, // get Passenger ID
        //            FullName = p.FullName // get Passenger Full Name
        //        });
        //    var combinedList = vipPassengers.Union(frequentFlyers) // combine both lists using Union
        //        .Distinct() // ensure distinct passengers
        //        .ToList(); // convert to list
        //    return combinedList; // return the combined list of passengers
        //}


        //12. 
        /* Conversion Operators Demonstration
        o
        Return ToDictionary of flights keyed by FlightNumber, ToArray of top 10 routes, AsEnumerable to switch to in-memory calculations for heavy operations, OfType example from mixed object collections. */
        // 12. Conversion Operators Demonstration
        public Dictionary<string, Flight> GetFlightsByFlightNumber()
        {
            return _flightRepository.GetAll() // get all flights from the repository
                .ToDictionary(f => f.FlightNumber); // convert to dictionary with FlightNumber as key
        }


        public List<Route> GetTop10Routes()
        {
            return _flightRepository.GetAll() // get all flights from the repository
                .GroupBy(f => f.Route) // group by Route
                .Select(g => g.Key) // select the Route
                .OrderByDescending(r => r.Flights.Count()) // order by number of flights descending
                .Take(10) // take top 10 routes
                .ToList(); // convert to list
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.GetAll() // get all flights from the repository
                .AsEnumerable(); // switch to in-memory calculations
        }
        public IEnumerable<T> GetOfType<T>(IEnumerable<object> mixedCollection) where T : class
        {
            return mixedCollection.OfType<T>(); // filter collection to return only items of type T
        }


        // 13. 
        /*Window-like Operation (running totals)
        o
        For each day, compute cumulative revenue (running sum). Implement via OrderBy and Select with aggregate accumulation.*/

        // 13. Window-like Operation (running totals)
        public List<DailyRevenueDto> GetCumulativeDailyRevenue(DateTime startDate, DateTime endDate)
        {
            var dailyRevenue = _ticketRepository.GetAll() // get all tickets from the repository
                .Where(t => t.Flight.DepartureUtc.Date >= startDate.Date &&
                            t.Flight.DepartureUtc.Date <= endDate.Date) // filter tickets by flight date range
                .GroupBy(t => t.Flight.DepartureUtc.Date) // group by flight departure date
                .Select(g => new DailyRevenueDto // class to hold daily revenue details
                {
                    Date = g.Key, // get the date
                    DailyRevenue = g.Sum(t => t.Fare) // sum of fares for the day
                })
                .OrderBy(d => d.Date) // order by date ascending
                .ToList(); // execute the query and get the results in a list

            // Calculate cumulative revenue
            decimal cumulativeSum = 0; // Change type to decimal to match DailyRevenue type

            foreach (var day in dailyRevenue)
            {
                cumulativeSum += day.DailyRevenue; // accumulate daily revenue
                day.CumulativeRevenue = cumulativeSum; // set cumulative revenue
            }
            return dailyRevenue; // return the list of daily revenues with cumulative totals
        }

        /*Forecasting (simple)
o
Using historical bookings, project expected bookings for next week by simple average or growth rate (exercise in LINQ + basic math).*/
        // 14. Forecasting (simple)
        public decimal ProjectBookingsForNextWeek(DateTime startDate, DateTime endDate)
        {
            var bookings = _ticketRepository.GetAll() // get all tickets from the repository
                .Where(t => t.Flight.DepartureUtc.Date >= startDate.Date &&
                            t.Flight.DepartureUtc.Date <= endDate.Date) // filter tickets by flight date range
                .GroupBy(t => t.Flight.DepartureUtc.Date) // group by flight departure date
                .Select(g => g.Count()) // count tickets for each day
                .ToList(); // convert to list
            if (bookings.Count == 0) return 0; // return 0 if no bookings found
            var averageBookings = bookings.Average(); // calculate average bookings per day
            return (decimal)averageBookings * 7; // project expected bookings for next week (7 days)

        }

        // -------------------- Helper Function --------------------
        // ---------------------  seat map ---------------------
        private static List<string> BuildSeatMap(int capacity)
        {
            var seats = new List<string>(capacity);
            if (capacity <= 0) return seats;
            const int perRow = 6;
            int rows = (int)Math.Ceiling(capacity / (double)perRow);
            for (int r = 1; r <= rows; r++)
            {
                for (int s = 0; s < perRow; s++)
                {
                    if (seats.Count >= capacity) break;
                    seats.Add($"{r}{(char)('A' + s)}");
                }
            }
            return seats;
        }

    }

}
