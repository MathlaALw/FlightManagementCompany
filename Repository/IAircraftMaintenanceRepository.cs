using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface IAircraftMaintenanceRepository
    {
        void Add(AircraftMaintenance aircraftMaintenance);
        void Delete(AircraftMaintenance aircraftMaintenance);
        IEnumerable<AircraftMaintenance> GetAll();
        AircraftMaintenance GetById(int id);
        void Update(AircraftMaintenance aircraftMaintenance);
    }
}