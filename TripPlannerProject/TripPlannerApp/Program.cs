using TripPlannerApp.Services;

TripPlanner planner = new();

while (true)
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("  Noah's Trip Planning Assistant");
    Console.WriteLine("===============================");
    Console.WriteLine("1. Manage Hotels");
    Console.WriteLine("2. Manage Trip Stops");
    Console.WriteLine("3. Manage Restaurants");
    Console.WriteLine("4. View Itinerary");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "1": planner.ManageHotels(); break;
        case "2": planner.ManageStops(); break;
        case "3": planner.ManageRestaurants(); break;
        case "4": planner.ViewItinerary(); break;
        case "5": return;
        default: Console.WriteLine("Invalid option. Press Enter to continue..."); Console.ReadLine(); break;
    }
}
