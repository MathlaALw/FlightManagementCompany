using FlightManagementCompany.Data;
using FlightManagementCompany.DTO;
using FlightManagementCompany.Models;
using FlightManagementCompany.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    new Ticket { SeatNumber = "1A", Fare = 500.00m, CheckedIn = true, BookingId = 1, FlightId = 21 },
                    new Ticket { SeatNumber = "1B", Fare = 600.00m, CheckedIn = false, BookingId = 2, FlightId = 22 },
                    new Ticket { SeatNumber = "1C", Fare = 550.00m, CheckedIn = true, BookingId = 3, FlightId = 23 },
                    new Ticket { SeatNumber = "1D", Fare = 700.00m, CheckedIn = false, BookingId = 4, FlightId = 24 },
                    new Ticket { SeatNumber = "1E", Fare = 650.00m, CheckedIn = true, BookingId = 5, FlightId = 25 },
                    new Ticket { SeatNumber = "1F", Fare = 800.00m, CheckedIn = false, BookingId = 6, FlightId = 26 },
                    new Ticket { SeatNumber = "2A", Fare = 520.00m, CheckedIn = true, BookingId = 7, FlightId = 27 },
                    new Ticket { SeatNumber = "2B", Fare = 620.00m, CheckedIn = false, BookingId = 8, FlightId = 28 },
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
        public IEnumerable<FlightManifestDto> GetDailyFlightManifest(DateTime dateUtc)
        {
            // Filter flights for the specific date (UTC)
            var flights = _flightRepository.GetAll() // get all flights from the repository
                .Where(f => f.DepartureUtc.Date == dateUtc.Date) // filter by date
                .Select(f => new FlightManifestDto // class to hold flight manifest details
                {
                    // flight fields in the manifest class
                    FlightNumber = f.FlightNumber,  // get flight number
                    DepUtc = f.DepartureUtc, // get departure time in UTC
                    ArrUtc = f.ArrivalUtc, // get arrival time in UTC
                    Origin = f.Route.OriginAirport.IATA, // get origin airport IATA code
                    Destination = f.Route.DestinationAirport.IATA, // get destination airport IATA code
                    AircraftTail = f.Aircraft.TailNumber, // get aircraft tail number
                    PassengerCount = f.Tickets.Count(), // count of tickets -> total passengers
                    TotalBaggageKg = f.Tickets // get all tickets for the flight
                                      .SelectMany(t => t.Baggages) // check all tickets for baggage
                                      .Sum(b => b.WeightKg), // sum of baggage weights
                    Crew = f.FlightCrew  // crew is List of FlightCrew -- > Name and Role
                            .Select(fc => new CrewDto // class to hold crew member details
                            {
                                Name = fc.CrewMember.FullName, // get crew member name
                                Role = fc.RoleOnFlight // get crew member role on the flight
                            })
                            .ToList() // convert to list
                })
                .ToList(); // execute the query and get the results in a list

            return flights; // return the list of flight manifests
        }

        //2. Top Routes by Revenue

        public IEnumerable<RouteRevenueDto> GetTopRoutesByRevenue(DateTime startDate, DateTime endDate)
        {
            var routeRevenue = _flightRepository.GetAll() // get all flights from the repository
                .Where(f => f.DepartureUtc.Date >= startDate.Date && f.DepartureUtc.Date <= endDate.Date) // filter flights by date range
                .SelectMany(f => f.Tickets, (f, t) => new { f.Route, t.Fare }) // flatten tickets with route
                .GroupBy(x => x.Route) // group by Route
                .Select(g => new RouteRevenueDto // class to hold route revenue details
                {
                    RouteId = g.Key.RouteId, // get Route ID
                    Origin = g.Key.OriginAirport.IATA, // get origin airport IATA code
                    Destination = g.Key.DestinationAirport.IATA, // get destination airport IATA code
                    Revenue = g.Sum(x => x.Fare), // sum of fares for the route
                    SeatsSold = g.Count(), // count of tickets sold for the route
                    AvgFare = g.Average(x => x.Fare) // average fare for the route
                })
                .OrderByDescending(r => r.Revenue) // order by revenue descending
                .ToList(); // execute the query and get the results in a list

            return routeRevenue; // return the list of route revenues
        }

        //3. On-Time Performance 
        public OnTimePerformanceDto GetOnTimePerformance(DateTime startDate, DateTime endDate)
        {
            var flights = _flightRepository.GetAll() // get all flights from the repository
                .Where(f => f.DepartureUtc.Date >= startDate.Date && f.DepartureUtc.Date <= endDate.Date) // filter flights by date range
                .ToList(); // execute the query and get the results in a list
            if (!flights.Any()) return new OnTimePerformanceDto(); // return empty DTO if no flights found
            var totalFlights = flights.Count; // total number of flights
            var onTimeFlights = flights.Count(f => f.Status == FlightStatus.Landed || f.Status == FlightStatus.Scheduled); // count of on-time flights
            var delayedFlights = totalFlights - onTimeFlights; // count of delayed flights
            return new OnTimePerformanceDto // class to hold on-time performance statistics
            {
                TotalFlights = totalFlights, // total number of flights
                OnTimeFlights = onTimeFlights, // count of on-time flights
                DelayedFlights = delayedFlights, // count of delayed flights
                OnTimePercentage = (double)onTimeFlights / totalFlights * 100 // calculate on-time percentage
            };

        }

        //4. Seat Occupancy Heatmap
        public IEnumerable<SeatOccupancyDto> GetSeatOccupancyHeatmap(DateTime startDate, DateTime endDate)
        {
            var heatmap = _ticketRepository.GetAll() // get all tickets from the repository
                .Where(t => t.Flight.DepartureUtc.Date >= startDate.Date && t.Flight.DepartureUtc.Date <= endDate.Date) // filter tickets by flight date range
                .GroupBy(t => new // group by Aircraft Tail and Seat Number
                {
                    t.Flight.Aircraft.TailNumber, 
                    t.SeatNumber
                })
                .Select(g => new SeatOccupancyDto // transform groups into DTOs
                {
                    AircraftTail = g.Key.TailNumber, // get Aircraft Tail Number
                    SeatNumber = g.Key.SeatNumber,  // get Seat Number
                    TimesOccupied = g.Count() // count how many times this seat was occupied
                })
                .OrderByDescending(s => s.TimesOccupied) // Sorts the list so the most frequently occupied seats come first
                .ToList(); // Convert to List

            return heatmap; // return the list of seat occupancy DTOs
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
        public IEnumerable<string> GetAvailableSeatsForFlight(int flightId)
        {
            var flight = _flightRepository.GetById(flightId);

            if (flight == null || flight.Aircraft == null)
                return Enumerable.Empty<string>();

            var bookedSeats = flight.Tickets?.Select(t => t.SeatNumber) ?? Enumerable.Empty<string>();
            var allSeats = Enumerable.Range(1, flight.Aircraft.Capacity).Select(n => n.ToString());

            return allSeats.Except(bookedSeats);
        }


        












        //5. Frequent Flyer Stats
        public IEnumerable<FrequentFlyerDto> GetFrequentFlyerStats(DateTime startDate, DateTime endDate)
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

        //6. Average Load Factor
        public double GetAverageLoadFactor(DateTime startDate, DateTime endDate)
        {
            var flights = _flightRepository.GetAll() // get all flights from the repository
                .Where(f => f.DepartureUtc.Date >= startDate.Date && f.DepartureUtc.Date <= endDate.Date) // filter flights by date range
                .ToList(); // execute the query and get the results in a list
            if (!flights.Any()) return 0; // return 0 if no flights found
            var totalSeats = flights.Sum(f => f.Aircraft.Capacity); // sum of all aircraft seat capacities
            var totalTicketsSold = flights.Sum(f => f.Tickets.Count()); // sum of all tickets sold for the flights
            return (double)totalTicketsSold / totalSeats * 100; // calculate average load factor as percentage
        }


        //7. Crew Scheduling Conflicts

        public IEnumerable<CrewConflictDto> GetCrewSchedulingConflicts()
        {
            // Get all flights with their crew and times
            var flightsWithCrew = _flightRepository.GetAll() // get all flights from the repository
                .Select(f => new // transform each flight into a DTO
                {
                    FlightId = f.FlightId, // get Flight ID
                    DepartureUtc = f.DepartureUtc, // get Departure time in UTC
                    ArrivalUtc = f.ArrivalUtc, // get Arrival time in UTC
                    Crew = f.FlightCrew.Select(fc => new // transform each FlightCrew into a DTO
                    {
                        CrewId = fc.CrewMember.CrewId, // get Crew ID
                        FullName = fc.CrewMember.FullName // get Crew Member Full Name
                    }).ToList() // convert to list
                    
                })
                .ToList(); // execute the query and get the results in a list


            var conflicts = new List<CrewConflictDto>(); // list to hold crew conflicts

            // Compare each flight with every other flight
            foreach (var flightA in flightsWithCrew) // iterate through each flight
            {
                foreach (var flightB in flightsWithCrew.Where(f => f.FlightId > flightA.FlightId)) // avoid duplicate pairs
                {
                    // Check for overlapping time
                    bool overlaps = flightA.DepartureUtc < flightB.ArrivalUtc &&
                                    flightB.DepartureUtc < flightA.ArrivalUtc;

                    if (overlaps)
                    {
                        // Find crew assigned to both flights
                        var overlappingCrew = flightA.Crew
                            .Join(flightB.Crew,
                                  ca => ca.CrewId,
                                  cb => cb.CrewId,
                                  (ca, cb) => new { ca.CrewId, ca.FullName })
                            .ToList();

                        // Add each conflict to the list
                        foreach (var crew in overlappingCrew)
                        {
                            conflicts.Add(new CrewConflictDto
                            {
                                CrewId = crew.CrewId,
                                CrewName = crew.FullName,
                                FlightAId = flightA.FlightId,
                                FlightBId = flightB.FlightId,
                                FlightADep = flightA.DepartureUtc,
                                FlightBDep = flightB.DepartureUtc
                            });
                        }
                    }
                }
            }

            return conflicts; // return the list of crew conflicts
        }


        //8. Passengers with Connections
        //public IEnumerable<PassengerConnectionDto> GetPassengersWithConnections(double maxHoursBetween)
        //{
        //    var result = _passengerRepository.GetAll() // get all passengers from the repository
        //        .Include(p => p.Bookings)
        //            .ThenInclude(b => b.FlightSegments)
        //                .ThenInclude(fs => fs.Flight)
        //        .Select(p => new PassengerConnectionDto
        //        {
        //            PassengerId = p.PassengerId,
        //            PassengerName = p.FullName,
        //            Legs = p.Bookings.SelectMany(b =>
        //                b.FlightSegments
        //                    .OrderBy(fs => fs.Flight.DepartureUtc)
        //                    .Zip(
        //                        b.FlightSegments
        //                            .OrderBy(fs => fs.Flight.DepartureUtc)
        //                            .Skip(1),
        //                        (prev, next) => new
        //                        {
        //                            BookingId = b.BookingId,
        //                            FromFlight = prev.Flight,
        //                            ToFlight = next.Flight,
        //                            HoursGap = (next.Flight.DepartureUtc - prev.Flight.ArrivalUtc).TotalHours
        //                        }
        //                    )
        //                    .Where(pair => pair.HoursGap >= 0 && pair.HoursGap <= maxHoursBetween)
        //                    .Select(pair => new ConnectionLegDto
        //                    {
        //                        FromFlightId = pair.FromFlight.FlightId,
        //                        FromArrival = pair.FromFlight.ArrivalUtc,
        //                        ToFlightId = pair.ToFlight.FlightId,
        //                        ToDeparture = pair.ToFlight.DepartureUtc,
        //                        HoursBetween = pair.HoursGap
        //                    })
        //            ).ToList(),
        //            BookingId = p.Bookings.FirstOrDefault()?.BookingId ?? 0
        //        })
        //        .Where(dto => dto.Legs.Any())
        //        .ToList();

        //    return result;
        //}


        // 9. 



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
