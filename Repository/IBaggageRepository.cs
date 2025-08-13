using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IBaggageRepository
    {
        void Add(Baggage baggage);
        void Delete(Baggage baggage);
        IEnumerable<Baggage> GetAll();
        Baggage GetById(int id);
        void Update(Baggage baggage);
    }
}