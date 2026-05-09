using System.ComponentModel.DataAnnotations;

namespace RentalApp.DTOs
{
    public class CreatePropertyDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        [Range(1, 100000)]
        public double PricePerNight { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;
    }
}
