using System.ComponentModel.DataAnnotations;

namespace CarRental.Dtos
{
    public class RentCar
    {
        public RentCar(string carName, DateTime from, DateTime to)
        {
            CarName = carName;
            From = from;
            To = to;
        }

        [Required]
        public string CarName { get; }
        [Required]
        public DateTime From { get; }
        [Required]
        public DateTime To { get; }
    }
}
