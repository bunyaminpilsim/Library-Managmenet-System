using CarSaleProject.Models;

namespace CarSaleProject.Repositories
{
    public interface ICarRepository
    {
        void AddCar(CarDTO car);
        List<CarDTO> GetAllCars();
        CarDTO GetCarByListingNumber(int listingNumber);
        void UpdateCar(CarDTO car);
        void DeleteCar(CarDTO car);

    }
}
