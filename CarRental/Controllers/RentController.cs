using CarRental.Dtos;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Rents : ControllerBase
    {
        private readonly IRentCars _rentCars;
        public Rents(IRentCars rentCars)
        {
            _rentCars = rentCars;
        }

        [HttpPost(nameof(RentingCars))]
        public string RentingCars([FromBody] RentDto rentDtos)
        {
            if (rentDtos is null || 
                rentDtos.Cars is null || 
                rentDtos.Cars.Count == 0)
            {
                return "Error Rent car";
            }

            return _rentCars.RentCar(rentDtos);
        }

        [HttpPut(nameof(ReturnedCars))]
        public string ReturnedCars([FromBody] ReturnedDto returnedCarDtos)
        {
            if (returnedCarDtos is null ||
                returnedCarDtos.Cars is null ||
                returnedCarDtos.Cars.Count == 0)
            {
                return "Error returned car";
            }

            return _rentCars.ReturnedCar(returnedCarDtos);
        }
    }
}
