namespace RentalApp.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public double PricePerNight { get; set; }
        public string City { get; set; }
        public int? OwnerId { get; set; }
    }
}
