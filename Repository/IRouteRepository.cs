using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IRouteRepository
    {
        void Add(Route route);
        void Delete(Route route);
        IEnumerable<Route> GetAll();
        Route GetById(int id);
        void Update(Route route);
    }
}