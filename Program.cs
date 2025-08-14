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


            // Average Load Factor
            Console.WriteLine("Calculating Average Load Factor...");
            Console.WriteLine("Enter the start date (yyyy-mm-dd):");
            string startDateInput = Console.ReadLine();
            DateTime startDate;
            while (!DateTime.TryParse(startDateInput, out startDate))
            {
                Console.WriteLine("Invalid date format. Please enter the start date (yyyy-mm-dd):");
                startDateInput = Console.ReadLine();
            }
            Console.WriteLine("Enter the end date (yyyy-mm-dd):");
            string endDateInput = Console.ReadLine();
            DateTime endDate;
            while (!DateTime.TryParse(endDateInput, out endDate))
            {
                Console.WriteLine("Invalid date format. Please enter the end date (yyyy-mm-dd):");
                endDateInput = Console.ReadLine();
            }
            var averageLoadFactor = flightService.GetAverageLoadFactor(startDate ,endDate);

        }
    }
}
