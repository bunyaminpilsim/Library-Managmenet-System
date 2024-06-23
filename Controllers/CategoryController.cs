using CarSaleProject.Models;
using CarSaleProject.Repositories;
using CategorySaleProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CategorySaleProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _carRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _carRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDTO category)
        {

            if (ModelState.IsValid)
            {

                if (category.File != null && category.File.Length > 0)
                {
                    DirectoryInfo fileType = new DirectoryInfo(category.File.FileName);
                    string fileName = Guid.NewGuid().ToString() + fileType.Extension;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        category.File.CopyToAsync(stream);
                    }
                    category.FilePath = "/img/" + fileName;
                }
                else
                {
                    ViewBag.Message = "Lütfen bir dosya seçin.";
                }

                _carRepository.AddCategory(category);
                return RedirectToAction("CategoryList");
            }

            return View(category);
        }

        public IActionResult CategoryList()
        {
            var cars = _carRepository.GetAllCategories();
            return View(cars);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int listingNumber)
        {
            var category = _carRepository.GetCategoryByListingNumber(listingNumber);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                _carRepository.UpdateCategory(category);
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int listingNumber)
        {

            var category = _carRepository.GetCategoryByListingNumber(listingNumber);
            if (category == null)
            {
                return NotFound();
            }
            _carRepository.DeleteCategory(category);
            return RedirectToAction("CategoryList");
        }
    }
}
