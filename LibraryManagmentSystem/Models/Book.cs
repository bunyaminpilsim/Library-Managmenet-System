using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? CoverImgPath { get; set; }
        public int PageCount { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}
