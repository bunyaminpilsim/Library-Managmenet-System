namespace CarSaleProject.Models
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public int ListingNumber { get; set; }

        public IFormFile? File { get; set; }
        public string? FilePath { get; set; }
    }
}
