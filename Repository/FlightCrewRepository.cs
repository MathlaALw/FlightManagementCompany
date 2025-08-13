using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class FlightCrewRepository : IFlightCrewRepository
    {

        private readonly FlightDbContext _context;
        public FlightCrewRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(FlightCrew flightCrew)
        {
            _context.FlightCrews.Add(flightCrew);
            _context.SaveChanges();
        }

        public void Update(FlightCrew flightCrew)
        {
            _context.FlightCrews.Update(flightCrew);
            _context.SaveChanges();
        }

        public void Delete(FlightCrew flightCrew)
        {
            _context.FlightCrews.Remove(flightCrew);
            _context.SaveChanges();
        }

        public FlightCrew GetById(int id) => _context.FlightCrews.Find(id);

        public IEnumerable<FlightCrew> GetAll() => _context.FlightCrews.ToList();



    }
}
