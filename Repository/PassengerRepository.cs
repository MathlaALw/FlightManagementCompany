using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class PassengerRepository : IPassengerRepository
    {

        private readonly FlightDbContext _context;
        public PassengerRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
        }

        public void Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            _context.SaveChanges();
        }

        public void Delete(Passenger passenger)
        {
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
        }

        public Passenger GetById(int id) => _context.Passengers.Find(id);

        public IEnumerable<Passenger> GetAll() => _context.Passengers.ToList();

    }
}
