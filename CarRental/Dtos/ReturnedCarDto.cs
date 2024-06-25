using System.ComponentModel.DataAnnotations;

namespace CarRental.Dtos
{
    public class ReturnedCarDto
    {
        public ReturnedCarDto(string carName, DateTime returnedDate)
        {
            CarName = carName;
            ReturnedDate = returnedDate;
        }

        [Required]
        public string CarName { get; }
        [Required]
        public DateTime ReturnedDate { get; }
    }
}
