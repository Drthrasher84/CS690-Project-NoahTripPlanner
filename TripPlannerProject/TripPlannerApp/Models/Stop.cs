namespace TripPlannerApp.Models
{
    public class Stop
    {
        public string Name { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public override string ToString() =>
            $"{Name} ({Notes})";
    }
}
