using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        List<Category> _categories=new List<Category>();

        public void AddCategory(Category category)
        {
           _categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _categories.Remove(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int id)
        {
           var category = _categories.FirstOrDefault(c => c.Id == id);

            return category;
        }

        public void UpdateCategory(Category category)
        {
           var exCategory=GetCategoryById(category.Id);
            if (exCategory != null)
            {
                exCategory.CategoryName=category.CategoryName;
            }
        }
    }
}
