using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementCompany.Repository
{
    public class RouteRepository : IRouteRepository
    {

        private readonly FlightDbContext _context;
        public RouteRepository(FlightDbContext context)
        {
            _context = context;
        }

        public void Add(Route route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
        }
        public void Update(Route route)
        {
            _context.Routes.Update(route);
            _context.SaveChanges();
        }

        public void Delete(Route route)
        {
            _context.Routes.Remove(route);
            _context.SaveChanges();
        }

        public Route GetById(int id) => _context.Routes.Find(id);

        public IEnumerable<Route> GetAll() => _context.Routes.ToList();


    }
}
