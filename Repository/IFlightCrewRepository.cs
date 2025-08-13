using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IFlightCrewRepository
    {
        void Add(FlightCrew flightCrew);
        void Delete(FlightCrew flightCrew);
        IEnumerable<FlightCrew> GetAll();
        FlightCrew GetById(int id);
        void Update(FlightCrew flightCrew);
    }
}