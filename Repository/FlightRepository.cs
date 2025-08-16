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
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext _context;
        public FlightRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }
        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }
        public void Delete(Flight flight)
        {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
        }
        public Flight GetById(int id) => _context.Flights.Find(id);
        public IEnumerable<Flight> GetAll() => _context.Flights.ToList();


        // Get Flights by Date Range
        public IEnumerable<Flight> GetFlightsByDateRange(DateTime from, DateTime to)
        {
            //return _context.Flights
            //    .Where(f => f.DepartureUtc >= from && f.ArrivalUtc <= to)
            //    .ToLi
            return _context.Flights
                .Include(f => f.Tickets)
                .Include(f => f.Route).ThenInclude(r => r.OriginAirport)
                .Include(f => f.Route).ThenInclude(r => r.DestinationAirport)
                .Where(f => f.DepartureUtc.Date >= from.Date &&
                            f.DepartureUtc.Date <= to.Date)
                .ToList();
        
        }

        // Get flight by Route
        public IEnumerable<Flight> GetFlightsByRoute(int routeId)
        {
            return _context.Flights
                .Where(f => f.RouteId == routeId)
                .ToList();
        }

        // Including Flight Details
        public Flight GetByIdIncludingDetails(int id)
        {
            return _context.Flights
                .Include(f => f.Aircraft)
                .Include(f => f.Tickets)
                .FirstOrDefault(f => f.FlightId == id);


        }

        // Get Flight By Ticket
        public Flight GetFlightByTicket(int ticketId)
        {
            return _context.Tickets
                .Where(t => t.TicketId == ticketId)
                .Select(t => t.Flight)
                .FirstOrDefault();
        }




    }
}
