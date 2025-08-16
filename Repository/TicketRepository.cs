using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class TicketRepository : ITicketRepository
    {

        private readonly FlightDbContext _context;
        public TicketRepository(FlightDbContext context)
        {
            _context = context;
        }


        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void Delete(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        public Ticket GetById(int id) => _context.Tickets.Find(id);

        public IEnumerable<Ticket> GetAll() => _context.Tickets.ToList();

        // Get Tickets by BookingRef
        public IEnumerable<Ticket> GetTicketsByBookingRef(string bookingRef)
        {

            // Find the BookingId for the given BookingRef
            var bookingId = _context.Bookings
                .Where(b => b.BookingRef == bookingRef)
                .Select(b => b.BookingId)
                .FirstOrDefault();

            // Return tickets for that BookingId
            return _context.Tickets
                .Where(t => t.BookingId == bookingId)
                .ToList();
        }

        // Get Tickets by PassengerId
        public IEnumerable<Ticket> GetTicketsByPassengerId(int passengerId)
        {
            // Find the bookingId for the given PassengerId
            var bookingId = _context.Bookings
                .Where(b => b.PassengerId == passengerId)
                .Select(b => b.BookingId)
                .FirstOrDefault();
            // Return tickets for that PassengerId
            return _context.Tickets
                .Where(t => t.BookingId == bookingId)
                .ToList();
        }


        // Get Tickets by Booking
        public Ticket GetTicketByBooking(int bookingId)
        {
            return _context.Tickets
                .FirstOrDefault(t => t.BookingId == bookingId);
        }
    }
}
