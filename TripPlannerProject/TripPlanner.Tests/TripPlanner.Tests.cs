using Xunit;
using TripPlannerApp.Models;

namespace TripPlanner.Tests
{
    public class TripPlannerTests
    {
        [Fact]
        public void AddHotel_ShouldIncreaseHotelCount()
        {
            var planner = new TripPlannerApp.Services.TripPlanner();
            int initial = planner.HotelCount;

            planner.TestAddHotel(new Hotel
            {
                Name = "Test Hotel",
                Address = "123 Main St",
                Day = "Day 1",
                CheckIn = "3pm",
                CheckOut = "11am"
            });

            Assert.Equal(initial + 1, planner.HotelCount);
        }

        [Fact]
        public void AddStop_ShouldIncreaseStopCount()
        {
            var planner = new TripPlannerApp.Services.TripPlanner();
            int initial = planner.StopCount;

            planner.TestAddStop(new Stop
            {
                Name = "Grand Canyon",
                Day = "Day 2",
                Notes = "Sunset hike"
            });

            Assert.Equal(initial + 1, planner.StopCount);
        }
    }
}
