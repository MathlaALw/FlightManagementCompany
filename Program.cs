using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using FlightManagementCompany.Service;

namespace FlightManagementCompany
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Check if the database exists, if not create it
            using FlightDbContext context = new FlightDbContext();
            context.Database.EnsureCreated();

            // Inject the context into the service
            FlightService flightService = new FlightService(context);

            //5. Available seats on a flight
            Console.WriteLine("Enter the flight ID to check available seats:");
            string? flightIdInput = Console.ReadLine(); // Allow null input
            int flightId;

            while (string.IsNullOrEmpty(flightIdInput) || !int.TryParse(flightIdInput, out flightId))
            {
                Console.WriteLine("Invalid flight ID. Please enter a valid flight ID:");
                flightIdInput = Console.ReadLine();
            }

            var availableSeats = flightService.GetAvailableSeatsForFlight(flightId);
            if (availableSeats.Any())
            {
                Console.WriteLine($"Available seats on flight {flightId}: {string.Join(", ", availableSeats)}");
            }
            else
            {
                Console.WriteLine($"No available seats found or flight with ID {flightId} does not exist.");
            }
        }
    }
}
