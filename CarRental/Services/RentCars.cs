using CarRental.Domain.Interfaces;
using CarRental.Dtos;
using CarRental.Services.Interfaces;
using System.Text;

namespace CarRental.Services
{
    public class RentCars : IRentCars
    {
        private readonly IRent _rent;
        public RentCars(IRent rent)
        {
            _rent = rent;
        }

        public string RentCar(RentDto rentDto)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rentDto.Cars.Count; i++)
            {
                var car = rentDto.Cars[i];
                result.AppendLine(_rent.CreateRent(car.CarName, rentDto.UserName, car.From, car.To));
            }

            return result.ToString();
        }

        public string ReturnedCar(ReturnedDto returnedCarDto)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < returnedCarDto.Cars.Count; i++)
            {
                var car = returnedCarDto.Cars[i];
                result.AppendLine(_rent.ReturnedCar(car.CarName, returnedCarDto.UserName, car.ReturnedDate));
            }
            return result.ToString();
        }
    }
}
