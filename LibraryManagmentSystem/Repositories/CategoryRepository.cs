using LibraryManagementSystem.Models;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();

        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            var exCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (exCategory != null)
            {
                exCategory.CategoryName=category.CategoryName;
                _context.SaveChanges();
            }

        }
    }
}
