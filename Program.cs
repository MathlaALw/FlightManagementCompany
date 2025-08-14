using FlightManagementCompany.Data;
using FlightManagementCompany.Service;

namespace FlightManagementCompany
{
    public class Program
    {
        static void Main(string[] args)
        {
            // check if the database exists, if not create it
            using FlightDbContext context = new FlightDbContext();
            context.Database.EnsureCreated();
            // Inject the context into the service
            FlightService flightService = new FlightService(context);

            // Create sample data
            // flightService.CreateSampleData();

        }
    }
}
