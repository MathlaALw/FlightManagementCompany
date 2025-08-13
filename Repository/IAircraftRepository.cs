using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IAircraftRepository
    {
        void Add(Aircraft aircraft);
        void Delete(Aircraft aircraft);
        IEnumerable<Aircraft> GetAll();
        Aircraft GetById(int id);
        IEnumerable<Aircraft> GetDueForMaintenance(DateTime beforeDate);
        void Update(Aircraft aircraft);
    }
}