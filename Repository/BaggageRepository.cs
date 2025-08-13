using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class BaggageRepository : IBaggageRepository
    {

        private readonly FlightDbContext _context;
        public BaggageRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(Baggage baggage)
        {
            _context.Baggages.Add(baggage);
            _context.SaveChanges();
        }

        public void Update(Baggage baggage)
        {
            _context.Baggages.Update(baggage);
            _context.SaveChanges();
        }

        public void Delete(Baggage baggage)
        {
            _context.Baggages.Remove(baggage);
            _context.SaveChanges();
        }

        public Baggage GetById(int id) => _context.Baggages.Find(id);

        public IEnumerable<Baggage> GetAll() => _context.Baggages.ToList();


    }
}
