using TripPlannerApp.Models;
using System.Text;

namespace TripPlannerApp.Utils
{
    public static class ItineraryFormatter
    {
        public static string FormatGroupedByDay(
            List<Hotel> hotels,
            List<Stop> stops,
            List<Restaurant> restaurants)
        {
            var sb = new StringBuilder();
            sb.AppendLine("--- Trip Itinerary (Grouped by Day) ---");

            var allDays = hotels.Select(h => h.Day)
                .Concat(stops.Select(s => s.Day))
                .Concat(restaurants.Select(r => r.Day))
                .Distinct()
                .OrderBy(day => day)
                .ToList();

            foreach (var day in allDays)
            {
                sb.AppendLine($"\nDay: {day}");

                var hotel = hotels.FirstOrDefault(h => h.Day == day);
                if (hotel != null) sb.AppendLine($"  [Hotel] {hotel}");

                var dayRestaurants = restaurants.Where(r => r.Day == day).ToList();
                if (dayRestaurants.Any())
                {
                    sb.AppendLine("  [Restaurants]:");
                    foreach (var r in dayRestaurants)
                        sb.AppendLine($"    - {r}");
                }

                var stopsForDay = stops.Where(s => s.Day == day).ToList();
                if (stopsForDay.Any())
                {
                    sb.AppendLine("  [Stops]:");
                    foreach (var s in stopsForDay)
                        sb.AppendLine($"    - {s.Name} ({s.Notes})");
                }
            }

            return sb.ToString();
        }
    }
}
