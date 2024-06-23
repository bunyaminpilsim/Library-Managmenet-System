using CarSaleProject.Data;
using CarSaleProject.Models;
using CarSaleProject.Repositories;

namespace CategorySaleProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryDTO _category)
        {
            Category category = new Category
            {
                Name = _category.Name,
                FilePath = _category.FilePath
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<Category> categories = _context.Categories.ToList();

            var categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                categoryDTOs.Add(new CategoryDTO
                {
                    ListingNumber = category.ListingNumber, 
                    Name = category.Name,
                    FilePath = category.FilePath
                });
            }

            return categoryDTOs;
        }

        public CategoryDTO GetCategoryByListingNumber(int listingNumber)
        {
            var category = _context.Categories.FirstOrDefault(c => c.ListingNumber == listingNumber);
            if (category == null) return null;

            return new CategoryDTO
            {
                ListingNumber = category.ListingNumber,
                Name = category.Name,
                FilePath = category.FilePath
            };
        }

        public void UpdateCategory(CategoryDTO category)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.ListingNumber == category.ListingNumber);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.FilePath = category.FilePath;
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(CategoryDTO category)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.ListingNumber == category.ListingNumber);
            if (existingCategory != null)
            {
                _context.Categories.Remove(existingCategory);
                _context.SaveChanges();
            }
        }
    }
}
