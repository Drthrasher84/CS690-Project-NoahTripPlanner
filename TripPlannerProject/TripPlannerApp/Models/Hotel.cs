namespace TripPlannerApp.Models
{
    public class Hotel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CheckIn { get; set; } = string.Empty;
        public string CheckOut { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;

        public override string ToString() =>
            $"{Name}, {Address} (Check-in: {CheckIn}, Check-out: {CheckOut})";
    }
}
