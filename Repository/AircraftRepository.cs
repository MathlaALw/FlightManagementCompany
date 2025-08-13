using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class AircraftRepository
    {

        private readonly FlightDbContext _context;
        public AircraftRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(Aircraft aircraft)
        {
            _context.Aircrafts.Add(aircraft);
            _context.SaveChanges();
        }

        public void Update(Aircraft aircraft)
        {
            _context.Aircrafts.Update(aircraft);
            _context.SaveChanges();
        }

        public void Delete(Aircraft aircraft)
        {
            _context.Aircrafts.Remove(aircraft);
            _context.SaveChanges();
        }

        public Aircraft GetById(int id) => _context.Aircrafts.Find(id);

        public IEnumerable<Aircraft> GetAll() => _context.Aircrafts.ToList();

        
        // Get Aircraft Due For Maintenance
        public IEnumerable<Aircraft> GetDueForMaintenance(DateTime beforeDate) // Method to get aircraft due for maintenance before a specific date
        {

            return _context.Aircrafts // Query the Aircrafts DbSet
                    .Include(a => a.AircraftMaintenances) // Include related AircraftMaintenances
                    .Where(a => a.AircraftMaintenances.Any(m => m.MaintenanceDate <= beforeDate)) // Filter aircraft that have any maintenance record before the specified date
                    .ToList(); // Convert the result to a list and return it
        }


    
    }
}
