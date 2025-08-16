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
            //Console.WriteLine("Enter the flight ID to check available seats:");
            //string? flightIdInput = Console.ReadLine(); // Allow null input
            //int flightId;

            //while (string.IsNullOrEmpty(flightIdInput) || !int.TryParse(flightIdInput, out flightId))
            //{
            //    Console.WriteLine("Invalid flight ID. Please enter a valid flight ID:");
            //    flightIdInput = Console.ReadLine();
            //}

            //var availableSeats = flightService.GetAvailableSeatsForFlight(flightId);
            //if (availableSeats.Any())
            //{
            //    Console.WriteLine($"Available seats on flight {flightId}: {string.Join(", ", availableSeats)}");
            //}
            //else
            //{
            //    Console.WriteLine($"No available seats found or flight with ID {flightId} does not exist.");
            //}


            // Main menu
            while (true)
            {
                Console.WriteLine("Welcome to the Flight Management System");
                Console.WriteLine("1. Daily Flight Manifest ");
                Console.WriteLine("2. Top Routes by Revenue");
                Console.WriteLine("3. On-Time Performance");
                Console.WriteLine("4. Seat Occupancy Heatmap");
                Console.WriteLine("5. Find Available Seats for a Flight");
                Console.WriteLine("6. Crew Scheduling Conflicts");
                Console.WriteLine("7. Passengers with Connections");
                Console.WriteLine("8. Frequent Fliers");
                Console.WriteLine("9. Maintenance Alert");
                Console.WriteLine("10. Baggage Overweight Alerts");
                Console.WriteLine("11. Complex Set/Partitioning Examples");
                Console.WriteLine("12. Conversion Operators Demonstration");
                Console.WriteLine("13. Window-like Operation (running totals)");
                Console.WriteLine("14. Forecasting (simple)");
                Console.WriteLine("6. Exit");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the Date (yyyy-MM-dd) to view the daily flight manifest:");
                        string? dateInput = Console.ReadLine();
                        DateTime date;
                        while (!DateTime.TryParse(dateInput, out date))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd):");
                            dateInput = Console.ReadLine();
                        }
                        flightService.GetDailyFlightManifest(date);
                        Console.WriteLine("Daily Flight Manifest for " + flightService);
                        break;
                    case "2":
                        // Add logic to add a new flight
                        break;
                    case "3":
                        // Add logic to update a flight
                        break;
                    case "4":
                        // Add logic to delete a flight
                        break;
                    case "5":
                        // Available seats logic is already implemented above
                        break;
                    case "6":
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }


        }
    }
}
