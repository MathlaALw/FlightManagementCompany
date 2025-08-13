using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IPassengerRepository
    {
        void Add(Passenger passenger);
        void Delete(Passenger passenger);
        IEnumerable<Passenger> GetAll();
        Passenger GetById(int id);
        void Update(Passenger passenger);
    }
}