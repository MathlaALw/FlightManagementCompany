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
