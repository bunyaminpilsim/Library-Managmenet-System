using System.ComponentModel.DataAnnotations;

namespace CarSaleProject.Data
{
    public class Category
    {
        [Key]
        public int ListingNumber { get; set; }
        public string Name { get; set; }

        public string? FilePath { get; set; }
    }
}
