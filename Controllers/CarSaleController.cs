using CarSaleProject.Models;
using CarSaleProject.Repositories;
using CategorySaleProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarSaleProject.Controllers
{
    public class CarSaleController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CarSaleController(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            List<CategoryDTO> categories = _categoryRepository.GetAllCategories();
            CarDTO car = new CarDTO();
            car.Categories = categories;

            return View(car);
        }

        [HttpPost]
        public IActionResult AddCar(CarDTO car)
        {

            if (ModelState.IsValid)
            {

                if (car.File != null && car.File.Length > 0)
                {
                    DirectoryInfo fileType = new DirectoryInfo(car.File.FileName);
                    string fileName = Guid.NewGuid().ToString()+ fileType.Extension;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        car.File.CopyToAsync(stream);
                    }
                    car.FilePath = "/img/" + fileName;
                }
                else
                {
                    ViewBag.Message = "Lütfen bir dosya seçin.";
                }

                _carRepository.AddCar(car);
                return RedirectToAction("CarList");
            }
            return View(car);
        }

        public IActionResult CarList()
        {
            var cars = _carRepository.GetAllCars();
            return View(cars);
        }

        [HttpGet]
        public IActionResult UpdateCar(int listingNumber)
        {
            var car = _carRepository.GetCarByListingNumber(listingNumber);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult UpdateCar(CarDTO car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.UpdateCar(car);
                return RedirectToAction("CarList");
            }
            return View(car);
        }

        [HttpGet]
        public IActionResult DeleteCar(int listingNumber)
        {

            var car = _carRepository.GetCarByListingNumber(listingNumber);
            if (car == null)
            {
                return NotFound();
            }
            _carRepository.DeleteCar(car);  
            return RedirectToAction("CarList");           
        }
    }
}

