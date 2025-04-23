using Xunit;
using TripPlannerApp.Models;
using TripPlannerApp.Utils;
using System.Collections.Generic;

namespace TripPlannerApp.Tests
{
    public class ItineraryFormatterTests
    {
        [Fact]
        public void FormatGroupedByDay_ShouldIncludeHotelStopAndRestaurant()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new Hotel
                {
                    Name = "Hotel Blue",
                    Address = "123 Main St",
                    Day = "Day 1",
                    CheckIn = "3pm",
                    CheckOut = "11am"
                }
            };

            var stops = new List<Stop>
            {
                new Stop
                {
                    Name = "Canyon Park",
                    Day = "Day 1",
                    Notes = "Viewpoint"
                }
            };

            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Taco Town",
                    Location = "Canyon Park",
                    Day = "Day 1"
                }
            };

            // Act
            string output = ItineraryFormatter.FormatGroupedByDay(hotels, stops, restaurants);

            // Assert
            Assert.Contains("Hotel Blue", output);
            Assert.Contains("Taco Town", output);
            Assert.Contains("Canyon Park", output);
            Assert.Contains("Day: Day 1", output);
        }
    }
}
