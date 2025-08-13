using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IFlightRepository
    {
        void Add(Flight flight);
        void Delete(Flight flight);
        IEnumerable<Flight> GetAll();
        Flight GetById(int id);
        IEnumerable<Flight> GetFlightsByDateRange(DateTime from, DateTime to);
        IEnumerable<Flight> GetFlightsByRoute(int routeId);
        void Update(Flight flight);
    }
}