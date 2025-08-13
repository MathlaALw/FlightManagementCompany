using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        void Delete(Booking booking);
        IEnumerable<Booking> GetAll();
        IEnumerable<Booking> GetBookingsByDateRange(DateTime from, DateTime to);
        Booking GetById(int id);
        void Update(Booking booking);
    }
}