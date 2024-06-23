using CarSaleProject.Models;

namespace CategorySaleProject.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(CategoryDTO car);
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryByListingNumber(int listingNumber);
        void UpdateCategory(CategoryDTO car);
        void DeleteCategory(CategoryDTO car);

    }
}
