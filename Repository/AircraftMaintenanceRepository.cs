using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class AircraftMaintenanceRepository
    {

        private readonly FlightDbContext _context;
        public AircraftMaintenanceRepository(FlightDbContext context)
        {
            _context = context;
        }
        public void Add(AircraftMaintenance aircraftMaintenance)
        {
            _context.AircraftMaintenances.Add(aircraftMaintenance);
            _context.SaveChanges();
        }
        public void Update(AircraftMaintenance aircraftMaintenance)
        {
            _context.AircraftMaintenances.Update(aircraftMaintenance);
            _context.SaveChanges();
        }

        public void Delete(AircraftMaintenance aircraftMaintenance)
        {
            _context.AircraftMaintenances.Remove(aircraftMaintenance);
            _context.SaveChanges();
        }

        public AircraftMaintenance GetById(int id)=>_context.AircraftMaintenances.Find(id);
        

        public IEnumerable<AircraftMaintenance> GetAll() => _context.AircraftMaintenances.ToList();
        


    }
}
