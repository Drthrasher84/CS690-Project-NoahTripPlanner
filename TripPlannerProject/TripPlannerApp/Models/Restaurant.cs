namespace TripPlannerApp.Models
{
    public class Restaurant
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;

        public override string ToString() =>
            $"{Name}, {Location}";
    }
}
