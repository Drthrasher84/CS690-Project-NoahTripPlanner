using TripPlannerApp.Services;

class Program
{
    static void Main()
    {
        var planner = new TripPlanner();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("  Noah's Trip Planning Assistant");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Manage Hotels");
            Console.WriteLine("2. Manage Trip Stops");
            Console.WriteLine("3. Manage Restaurants");
            Console.WriteLine("4. View Itinerary");
            Console.WriteLine("5. Export Itinerary");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": planner.ManageHotels(); break;
                case "2": planner.ManageStops(); break;
                case "3": planner.ManageRestaurants(); break;
                case "4": planner.ViewItinerary(); break;
                case "5": planner.ExportItinerary(); break;
                case "6": return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
