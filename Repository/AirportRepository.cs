using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlightDbContext _context;
        public AirportRepository(FlightDbContext context)
        {
            _context = context;
        }


        public void Add(Airport airport)
        {
            _context.Airports.Add(airport);
            _context.SaveChanges();
        }

        public void Update(Airport airport)
        {
            _context.Airports.Update(airport);
            _context.SaveChanges();
        }

        public void Delete(Airport airport)
        {
            _context.Airports.Remove(airport);
            _context.SaveChanges();
        }


        public Airport GetById(int id) => _context.Airports.Find(id);

        public IEnumerable<Airport> GetAll() => _context.Airports.ToList();


    }
}
