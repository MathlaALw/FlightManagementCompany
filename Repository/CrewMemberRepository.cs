using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class CrewMemberRepository : ICrewMemberRepository
    {

        private readonly FlightDbContext _context;
        public CrewMemberRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(CrewMember crewMember)
        {
            _context.CrewMembers.Add(crewMember);
            _context.SaveChanges();
        }

        public void Update(CrewMember crewMember)
        {
            _context.CrewMembers.Update(crewMember);
            _context.SaveChanges();
        }

        public void Delete(CrewMember crewMember)
        {
            _context.CrewMembers.Remove(crewMember);
            _context.SaveChanges();
        }


        public CrewMember GetById(int id) => _context.CrewMembers.Find(id);

        public IEnumerable<CrewMember> GetAll() => _context.CrewMembers.ToList();

        // Get Crew Members by Role
        public IEnumerable<CrewMember> GetCrewMembersByRole(string role)
        {
            return _context.CrewMembers // Access the CrewMembers DbSet
                .Where(cm => cm.Role.ToString().Equals(role, StringComparison.OrdinalIgnoreCase)) // Filter by Role -- .Equals(role, StringComparison.OrdinalIgnoreCase) compares the role ignoring case.
                .ToList();
        }

        // Get Available Crew (DateTime Dep)
        public IEnumerable<CrewMember> GetAvailableCrew(DateTime departureDate)
        {
            return _context.CrewMembers
                    .Where(cm => !cm.FlightCrews // Check if the crew member is not assigned to any flight crew
                        .Any(fc => fc.Flight.DepartureUtc.Date == departureDate.Date)) // Check if the crew member is not assigned to any flight crew on the specified departure date
                    .ToList(); // Convert the result to a list and return it
        }


    }
}
