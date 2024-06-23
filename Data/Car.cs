using System.ComponentModel.DataAnnotations;

namespace CarSaleProject.Data
{
    public class Car
    {
        [Key]
        public int ListingNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime ListingDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public int Kilometers { get; set; }
        public string? FilePath { get; set; }
        public int SeatNumber { get; set; }
        public int CategoryId { get; set; }

    }
}
