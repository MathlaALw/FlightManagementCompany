using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket);
        void Delete(Ticket ticket);
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        IEnumerable<Ticket> GetTicketsByBookingRef(string bookingRef);
        IEnumerable<Ticket> GetTicketsByPassengerId(int passengerId);
        void Update(Ticket ticket);
    }
}