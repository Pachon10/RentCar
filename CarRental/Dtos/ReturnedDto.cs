using System.ComponentModel.DataAnnotations;

namespace CarRental.Dtos
{
    public class ReturnedDto
    {
        public ReturnedDto(string userName, List<ReturnedCarDto> cars)
        {
            UserName = userName;
            Cars = cars;
        }

        [Required]
        public string UserName { get; }
        [Required]
        public List<ReturnedCarDto> Cars { get; }
    }
}
