using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IAirportRepository
    {
        void Add(Airport airport);
        void Delete(Airport airport);
        IEnumerable<Airport> GetAll();
        Airport GetById(int id);
        void Update(Airport airport);
    }
}