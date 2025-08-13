using FlightManagementCompany.Models;

namespace FlightManagementCompany.Repository
{
    public interface ICrewMemberRepository
    {
        void Add(CrewMember crewMember);
        void Delete(CrewMember crewMember);
        IEnumerable<CrewMember> GetAll();
        IEnumerable<CrewMember> GetAvailableCrew(DateTime departureDate);
        CrewMember GetById(int id);
        IEnumerable<CrewMember> GetCrewMembersByRole(string role);
        void Update(CrewMember crewMember);
    }
}