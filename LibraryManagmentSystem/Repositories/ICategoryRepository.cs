using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);

    }
}
