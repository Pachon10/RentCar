using CarRental.Dtos;

namespace CarRental.Services.Interfaces
{
    public interface IRentCars
    {
        public string RentCar(RentDto rentDto);
        public string ReturnedCar(ReturnedDto rentDto);
    }
}
