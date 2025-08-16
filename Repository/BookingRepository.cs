using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly FlightDbContext _context;
        public BookingRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }

        public Booking GetById(int id) => _context.Bookings.Find(id);

        public IEnumerable<Booking> GetAll() => _context.Bookings.ToList();


        // Get Booking by Date Range 
        public IEnumerable<Booking> GetBookingsByDateRange(DateTime from, DateTime to)
        {
            return _context.Bookings
                .Where(b => b.BookingDate >= from && b.BookingDate <= to)
                .ToList();
        }

        // Get Booking by Passenger
        public IEnumerable<Booking> GetBookingsByPassenger(int passengerId)
        {
            return _context.Bookings
                .Where(b => b.PassengerId == passengerId)
                .ToList();
        }
    }
}
