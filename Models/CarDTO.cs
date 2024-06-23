namespace CarSaleProject.Models
{
    public class CarDTO
    {
        public decimal Price { get; set; }
        public DateTime ListingDate { get; set; }
        public int? ListingNumber { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Kilometers { get; set; }
        public IFormFile? File { get; set; }
        public string? FilePath { get; set; }
        public int SeatNumber { get; set; }
        public int? CategoryId { get; set; }
        public List<CategoryDTO>? Categories { get; set; }

    }
}
