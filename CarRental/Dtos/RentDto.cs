using System.ComponentModel.DataAnnotations;

namespace CarRental.Dtos
{
    public class RentDto
    {
        public RentDto(string userName, List<RentCar> cars)
        {
            UserName = userName;
            Cars = cars;
        }

        [Required]
        public string UserName { get; }
        [Required]
        public List<RentCar> Cars { get; }

    }
}
