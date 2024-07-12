namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;   
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string City { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
