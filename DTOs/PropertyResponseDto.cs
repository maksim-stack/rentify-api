namespace RentalApp.DTOs
{
    public class PropertyResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public double PricePerNight { get; set; }
        public required string City { get; set; }
    }
}
