namespace CarRental.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = default!;
        public int CarId { get; set; }
        public Car Car { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public decimal TotalPrice { get; set; }
    }
}
