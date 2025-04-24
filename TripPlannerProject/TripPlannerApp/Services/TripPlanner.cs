using TripPlannerApp.Models;
using TripPlannerApp.Utils;
using System.Text;

namespace TripPlannerApp.Services;

public class TripPlanner
{
    private readonly List<Hotel> hotels = new();
    private readonly List<Stop> stops = new();
    private readonly List<Restaurant> restaurants = new();

    public void ManageHotels()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Manage Hotels ---");
            Console.WriteLine("1. Add Hotel\n2. View Hotels\n3. Edit Hotel\n4. Delete Hotel\n5. Back");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddHotel(); break;
                case "2": ViewHotels(); break;
                case "3": EditHotel(); break;
                case "4": DeleteHotel(); break;
                default: return;
            }
        }
    }

    public void ManageStops()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Manage Trip Stops ---");
            Console.WriteLine("1. Add Stop\n2. View Stops\n3. Edit Stop\n4. Delete Stop\n5. Back");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddStop(); break;
                case "2": ViewStops(); break;
                case "3": EditStop(); break;
                case "4": DeleteStop(); break;
                default: return;
            }
        }
    }

    public void ManageRestaurants()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Manage Restaurants ---");
            Console.WriteLine("1. Add Restaurant\n2. View Restaurants\n3. Edit Restaurant\n4. Delete Restaurant\n5. Back");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddRestaurant(); break;
                case "2": ViewRestaurants(); break;
                case "3": EditRestaurant(); break;
                case "4": DeleteRestaurant(); break;
                default: return;
            }
        }
    }

    public void ViewItinerary()
        {
            Console.Clear();
            string formatted = ItineraryFormatter.FormatGroupedByDay(hotels, stops, restaurants);
            Console.WriteLine(formatted);
            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
        }


    public void ExportItinerary()
    {
        Console.Clear();
        Console.Write("Enter filename to export (e.g., itinerary.txt): ");
        string? input = Console.ReadLine();
        string fileName = string.IsNullOrWhiteSpace(input) ? "itinerary.txt" : input;

        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = "itinerary.txt";
        }

        string formatted = ItineraryFormatter.FormatGroupedByDay(hotels, stops, restaurants);

        try
        {
            File.WriteAllText(fileName, formatted);
            Console.WriteLine($"Itinerary exported to '{fileName}' successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error saving file: {ex.Message}");
        }

        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();
    }

    private void AddHotel()
    {
        var hotel = new Hotel();
        Console.Write("Hotel name: "); hotel.Name = Console.ReadLine() ?? "";
        Console.Write("Address: "); hotel.Address = Console.ReadLine() ?? "";
        Console.Write("Check-in time: "); hotel.CheckIn = Console.ReadLine() ?? "";
        Console.Write("Check-out time: "); hotel.CheckOut = Console.ReadLine() ?? "";
        Console.Write("Day of stay (e.g., Day 1): "); hotel.Day = Console.ReadLine() ?? "";
        hotels.Add(hotel);
        Console.WriteLine("Hotel added. Press Enter to continue...");
        Console.ReadLine();
    }

    private void EditHotel()
    {
        ViewHotels();
        Console.Write("Enter index to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < hotels.Count)
        {
            var h = hotels[index];
            Console.Write($"Hotel name ({h.Name}): "); h.Name = Console.ReadLine() ?? h.Name;
            Console.Write($"Address ({h.Address}): "); h.Address = Console.ReadLine() ?? h.Address;
            Console.Write($"Check-in time ({h.CheckIn}): "); h.CheckIn = Console.ReadLine() ?? h.CheckIn;
            Console.Write($"Check-out time ({h.CheckOut}): "); h.CheckOut = Console.ReadLine() ?? h.CheckOut;
            Console.Write($"Day of stay ({h.Day}): "); h.Day = Console.ReadLine() ?? h.Day;
        }
    }

    private void DeleteHotel()
    {
        ViewHotels();
        Console.Write("Enter index to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < hotels.Count)
        {
            hotels.RemoveAt(index);
            Console.WriteLine("Hotel removed. Press Enter to continue...");
            Console.ReadLine();
        }
    }

    private void ViewHotels()
    {
        Console.WriteLine("--- Hotels ---");
        for (int i = 0; i < hotels.Count; i++)
            Console.WriteLine($"[{i}] {hotels[i]}");
        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    private void AddStop()
    {
        var stop = new Stop();
        Console.Write("Stop name: "); stop.Name = Console.ReadLine() ?? "";
        Console.Write("Day of visit: "); stop.Day = Console.ReadLine() ?? "";
        Console.Write("Notes (optional): "); stop.Notes = Console.ReadLine() ?? "";
        stops.Add(stop);
        Console.WriteLine("Stop added. Press Enter to continue...");
        Console.ReadLine();
    }

    private void EditStop()
    {
        ViewStops();
        Console.Write("Enter index to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < stops.Count)
        {
            var s = stops[index];
            Console.Write($"Stop name ({s.Name}): "); s.Name = Console.ReadLine() ?? s.Name;
            Console.Write($"Day of visit ({s.Day}): "); s.Day = Console.ReadLine() ?? s.Day;
            Console.Write($"Notes ({s.Notes}): "); s.Notes = Console.ReadLine() ?? s.Notes;
        }
    }

    private void DeleteStop()
    {
        ViewStops();
        Console.Write("Enter index to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < stops.Count)
        {
            stops.RemoveAt(index);
            Console.WriteLine("Stop removed. Press Enter to continue...");
            Console.ReadLine();
        }
    }

    private void ViewStops()
    {
        Console.WriteLine("--- Trip Stops ---");
        for (int i = 0; i < stops.Count; i++)
            Console.WriteLine($"[{i}] {stops[i]}");
        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    private void AddRestaurant()
    {
        var restaurant = new Restaurant();
        Console.Write("Restaurant name: "); restaurant.Name = Console.ReadLine() ?? "";
        Console.Write("Location (associated stop or city): "); restaurant.Location = Console.ReadLine() ?? "";
        Console.Write("Day of visit (e.g., Day 1): "); restaurant.Day = Console.ReadLine() ?? "";
        restaurants.Add(restaurant);
        Console.WriteLine("Restaurant added. Press Enter to continue...");
        Console.ReadLine();
    }

    private void EditRestaurant()
    {
        ViewRestaurants();
        Console.Write("Enter index to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < restaurants.Count)
        {
            var r = restaurants[index];
            Console.Write($"Restaurant name ({r.Name}): "); r.Name = Console.ReadLine() ?? r.Name;
            Console.Write($"Location ({r.Location}): "); r.Location = Console.ReadLine() ?? r.Location;
            Console.Write($"Day of visit ({r.Day}): "); r.Day = Console.ReadLine() ?? r.Day;
        }
    }

    private void DeleteRestaurant()
    {
        ViewRestaurants();
        Console.Write("Enter index to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < restaurants.Count)
        {
            restaurants.RemoveAt(index);
            Console.WriteLine("Restaurant removed. Press Enter to continue...");
            Console.ReadLine();
        }
    }

    private void ViewRestaurants()
    {
        Console.WriteLine("--- Restaurants ---");
        for (int i = 0; i < restaurants.Count; i++)
            Console.WriteLine($"[{i}] {restaurants[i]}");
        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }

    // Helper methods for unit testing
    public int HotelCount => hotels.Count;
    public int StopCount => stops.Count;
    public int RestaurantCount => restaurants.Count;
    public void TestAddHotel(Hotel hotel) => hotels.Add(hotel);
    public void TestAddStop(Stop stop) => stops.Add(stop);
    public void TestAddRestaurant(Restaurant r) => restaurants.Add(r);
}
