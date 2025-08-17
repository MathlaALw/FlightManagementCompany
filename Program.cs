using FlightManagementCompany.Data;
using FlightManagementCompany.Models;
using FlightManagementCompany.Service;
using Microsoft.Identity.Client;
using System.Globalization;

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
                Console.WriteLine("0. Exit");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        Console.WriteLine("Enter the date (yyyy-MM-dd) to view the daily flight manifest:");
                        string? dateInput = Console.ReadLine();

                        DateTime dateUtc; // we'll treat it as a UTC calendar day
                        while (!DateTime.TryParse(dateInput, out dateUtc))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid  date (yyyy-MM-dd):");
                            dateInput = Console.ReadLine();
                        }

                        // Call your service
                        var manifest = flightService.GetDailyFlightManifest(dateUtc);

                        // Helpful sanity line
                        Console.WriteLine($"\nFlights found for {dateUtc:yyyy-MM-dd} (UTC): {manifest.Count}\n");

                        if (manifest.Count == 0)
                        {
                            Console.WriteLine("No flights depart on this date.");
                            return;
                        }

                        foreach (var flight in manifest)
                        {
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine($"FlightID        : {flight.FlightId}");
                            Console.WriteLine($"Flight Number   : {flight.FlightNumber}");
                            Console.WriteLine($"Departure (IATA): {flight.Origin}");
                            Console.WriteLine($"Arrival (IATA)  : {flight.Destination}");
                            Console.WriteLine($"Departure Time  : {flight.DepUtc:yyyy-MM-dd HH:mm} (UTC)");
                            Console.WriteLine($"Arrival Time    : {flight.ArrUtc:yyyy-MM-dd HH:mm} (UTC)");
                            Console.WriteLine($"Aircraft Tail   : {flight.AircraftTail}");
                            Console.WriteLine($"Passenger Count : {flight.PassengerCount}");
                            Console.WriteLine($"Total BaggageKg : {flight.TotalBaggageKg}");
                            Console.WriteLine("Crew Members    :");

                            if (flight.Crew == null || flight.Crew.Count == 0)
                            {
                                Console.WriteLine("  (none)");
                            }
                            else
                            {
                                foreach (var crew in flight.Crew)
                                {
                                    // If your CrewDto doesn't have CrewId, remove this line.
                                    // Console.WriteLine($"  Crew ID : {crew.CrewId}");
                                    Console.WriteLine($"  Name    : {crew.Name}");
                                }
                            }
                        }

                                    //Console.WriteLine("Daily Flight Manifest for " + flightService);
                                    break;
                    case "2":
                        //Top Routes by Revenue
                        Console.WriteLine("Enter the Start Date (yyyy-MM-dd):");
                        string? startDateInput = Console.ReadLine();
                        DateTime startDate;
                        while (!DateTime.TryParse(startDateInput, out startDate))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid start date (yyyy-MM-dd):");
                            startDateInput = Console.ReadLine();
                        }
                        Console.WriteLine("Enter the End Date (yyyy-MM-dd):");
                        string? endDateInput = Console.ReadLine();
                        DateTime endDate;
                        while (!DateTime.TryParse(endDateInput, out endDate) || endDate < startDate)
                        {
                            Console.WriteLine(endDate < startDate
                                ? "End date must be after start date. Please enter a valid end date (yyyy-MM-dd):"
                                : "Invalid date format. Please enter a valid end date (yyyy-MM-dd):");
                            endDateInput = Console.ReadLine();
                        }
                        var topRoutes = flightService.GetRouteRevenue(startDate, endDate);
                        if (topRoutes.Any())
                        {
                            Console.WriteLine("Top Routes by Revenue:");
                            foreach (var route in topRoutes)
                            {
                                Console.WriteLine($"Route: {route.Origin} to {route.Destination}, Revenue: {route.Revenue:C}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No routes found for the specified date range.");
                        }
                        break;
                    case "3":
                        // On-Time Performance
                        Console.WriteLine("Enter the Start Date (yyyy-MM-dd):");
                        string? otpStartDateInput = Console.ReadLine();
                        DateTime otpStartDate;
                        while (!DateTime.TryParse(otpStartDateInput, out otpStartDate))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid start date (yyyy-MM-dd):");
                            otpStartDateInput = Console.ReadLine();
                        }
                        Console.WriteLine("Enter the End Date (yyyy-MM-dd):");
                        string? otpEndDateInput = Console.ReadLine();
                        DateTime otpEndDate;

                        while (!DateTime.TryParse(otpEndDateInput, out otpEndDate) || otpEndDate < otpStartDate)
                        {
                            Console.WriteLine(otpEndDate < otpStartDate
                                ? "End date must be after start date. Please enter a valid end date (yyyy-MM-dd):"
                                : "Invalid date format. Please enter a valid end date (yyyy-MM-dd):");
                            otpEndDateInput = Console.ReadLine();
                        }
                        var onTimePerformance = flightService.GetOnTimePerformance(otpStartDate, otpEndDate);
                       
                            Console.WriteLine("On-Time Performance:");
                       

                            Console.WriteLine("On-Time Performance:");
                            Console.WriteLine($"Total Flights: {onTimePerformance.TotalFlights}");
                            Console.WriteLine($"On-Time Flights: {onTimePerformance.OnTimeFlights}");
                            Console.WriteLine($"On-Time Percentage: {onTimePerformance.OnTimePercentage:P2}");
                            Console.WriteLine($"Delayed Flights: {onTimePerformance.DelayedFlights}");
                            Console.WriteLine("--------------------------------------------------");


                        break;
                    case "4":
                        // Seat Occupancy Heatmap
                        Console.WriteLine("Enter the Start Date (yyyy-MM-dd):");
                        string? heatmapStartDateInput = Console.ReadLine();
                        DateTime heatmapStartDate;
                        while (!DateTime.TryParse(heatmapStartDateInput, out heatmapStartDate))
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid start date (yyyy-MM-dd):");
                            heatmapStartDateInput = Console.ReadLine();
                        }
                        Console.WriteLine("Enter the End Date (yyyy-MM-dd):");
                        string? heatmapEndDateInput = Console.ReadLine();
                        DateTime heatmapEndDate;
                        while (!DateTime.TryParse(heatmapEndDateInput, out heatmapEndDate) || heatmapEndDate < heatmapStartDate)
                        {
                            Console.WriteLine(heatmapEndDate < heatmapStartDate
                                ? "End date must be after start date. Please enter a valid end date (yyyy-MM-dd):"
                                : "Invalid date format. Please enter a valid end date (yyyy-MM-dd):");
                            heatmapEndDateInput = Console.ReadLine();
                        }
                        var heatmapData = flightService.GetSeatOccupancyHeatmap(heatmapStartDate, heatmapEndDate);
                        
                            Console.WriteLine("Seat Occupancy Heatmap:");
                            foreach (var data in heatmapData)
                            {
                           
                            Console.WriteLine($"Aircraft Tail: {data.AircraftTail}, Seat Number: {data.SeatNumber}, Times Occupied: {data.TimesOccupied}");
                        }
                        Console.WriteLine("--------------------------------------------------");
                





                        break;

                    case "5":

                        Console.WriteLine("Enter the flight ID to check available seats:");
                        int flightId;
                        string? flightIdInput = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(flightIdInput) || !int.TryParse(flightIdInput, out flightId))
                        {
                            Console.WriteLine("Invalid flight ID. Please enter a valid flight ID:");
                            flightIdInput = Console.ReadLine();
                        }

                        // Call your service
                        var seatsEnumerable = flightService.GetAvailableSeatsForFlight(flightId);
                        if (seatsEnumerable == null)
                        {
                            Console.WriteLine($"Flight with ID {flightId} does not exist.");
                            return;
                        }

                        // Materialize and sort seats: numeric row then seat letter
                        var seats = seatsEnumerable
                            .Select(s => s?.Trim())
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .OrderBy(s => int.Parse(new string(s.TakeWhile(char.IsDigit).ToArray())))
                            .ThenBy(s => new string(s.SkipWhile(char.IsDigit).ToArray()))
                            .ToList();

                        // If the service returns an empty sequence, we can’t tell if flight doesn’t exist or no capacity.
                        // If you exposed a separate flight lookup, use it here to print a more specific message.
                        if (seats.Count == 0)
                        {
                            Console.WriteLine($"No available seats found for flight ID {flightId}. (Flight may be full or not found.)");
                            return;
                        }

                        Console.WriteLine($"\nAvailable seats on flight {flightId}: {seats.Count}\n");

                        // Print in columns (e.g., 10 per line)
                        const int perLine = 10;
                        for (int i = 0; i < seats.Count; i++)
                        {
                            Console.Write(seats[i]);
                            if ((i + 1) % perLine == 0 || i == seats.Count - 1)
                                Console.WriteLine();
                            else
                                Console.Write(", ");
                        }

                        break;

                        case "6":
                        //Crew Scheduling Conflicts

                        
                        Console.WriteLine("Crew Scheduling Conflicts:");
                        var conflicts = flightService.GetCrewSchedulingConflicts();
                        if (conflicts.Any())
                        {
                            foreach (var conflict in conflicts)
                            {
                                
                                Console.WriteLine($"Crew ID: {conflict.CrewId}, Crew Name: {conflict.CrewName}, Crew Licence: {conflict.CrewLicence}");
                                Console.WriteLine($"Flight A ID: {conflict.FlightAId}, Flight B ID: {conflict.FlightBId}");
                                Console.WriteLine($"Flight A Departure: {conflict.FlightADep}, Flight B Departure: {conflict.FlightBDep}");
                                Console.WriteLine("--------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No scheduling conflicts found.");
                        }

                        break;

                    case "7":
                        Console.WriteLine("Passengers with Connections");
                        Console.WriteLine("Enter the flight ID to find passengers with connections:");
                        int flightIdForConnections;
                        string? flightIdForConnectionsInput = Console.ReadLine(); // Allow null input
                        while (string.IsNullOrEmpty(flightIdForConnectionsInput) || !int.TryParse(flightIdForConnectionsInput, out flightIdForConnections))
                        {
                            Console.WriteLine("Invalid flight ID. Please enter a valid flight ID:");
                            flightIdForConnectionsInput = Console.ReadLine();
                        }
                        var passengersWithConnections = flightService.GetPassengersWithConnections(flightIdForConnections);
                        if (passengersWithConnections.Any())
                        {
                            Console.WriteLine($"Passengers with connections on flight {flightIdForConnections}:");
                            foreach (var passenger in passengersWithConnections)
                            {
                                Console.WriteLine($"Passenger ID: {passenger.PassengerId}, Name: {passenger.Name}, Connection Flight ID: {passenger.ConnectingFlights}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No passengers with connections found for flight {flightIdForConnections}.");
                        }
                        break;

                    case "0":
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }




        // Common Function 
        // Get start and end date from user and return them as a tuple
        //public void GetStartAndEndDate(out DateTime startDate, out DateTime endDate)
        //{
        //    // Get start date
        //    Console.WriteLine("Enter the Start Date (yyyy-MM-dd):");
        //    string? startDateInput = Console.ReadLine();
        //    while (string.IsNullOrEmpty(startDateInput) || !DateTime.TryParse(startDateInput, out startDate))
        //    {
        //        Console.WriteLine("Invalid date format. Please enter a valid start date (yyyy-MM-dd):");
        //        startDateInput = Console.ReadLine();
        //    }

        //    // Get end date
        //    Console.WriteLine("Enter the End Date (yyyy-MM-dd):");
        //    string? endDateInput = Console.ReadLine();
        //    while (string.IsNullOrEmpty(endDateInput) || !DateTime.TryParse(endDateInput, out endDate) || endDate < startDate)
        //    {
        //        Console.WriteLine(endDate < startDate
        //            ? "End date must be after start date. Please enter a valid end date (yyyy-MM-dd):"
        //            : "Invalid date format. Please enter a valid end date (yyyy-MM-dd):");
        //        endDateInput = Console.ReadLine();
        //    }
        //}



    }
}
