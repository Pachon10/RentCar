using CarRental.Data;
using CarRental.Entities;
using CarRental.Common;
using CarRental.Domain.Interfaces;

namespace CarRental.Domain
{
    public class Rent : IRent
    {
        public readonly Datas _data;
        public readonly ICalculatePrice _calculatePrice;

        public Rent(Datas data, ICalculatePrice calculatePrice)
        {
            _data = data;
            _calculatePrice = calculatePrice;
        }

        public string CreateRent(string carName, string nameUser, DateTime from, DateTime to)
        {
            if (!_data.Cars!.TryGetValue(carName, out var typeCar))
            {
                return $"Car {carName} not found.";
            }

            int days = Utils.GetDays(from, to);

            if (days == 0)
            {
                return "The days should be 1 or greater";
            }

            double total = _calculatePrice.TotalPrices(typeCar, days);

            if (total == 0)
            {
                return "Error prices";
            }

            if (!_data.LoyaltyPoints!.TryGetValue(typeCar, out var loyaltyPoints))
            {
                loyaltyPoints = 0;
            }

            Rents rent = new(carName, typeCar, nameUser, loyaltyPoints, from, to, total, 0);

            if (!_data.Rents!.TryGetValue(nameUser, out var rents))
            {
                rents = AddNewRents(rent, rents);
                _data.Rents!.Add(nameUser, rents);
            }
            else
            {
                rents = AddNewRents(rent, rents);
            }

            return rent.ToString();
        }

        public string ReturnedCar(string carName, string nameUser, DateTime day)
        {
            if (!_data.Rents!.TryGetValue(nameUser, out var rents))
            {
                return "User error";
            }

            var rent = rents.Where(x => x.CarName == carName && !x.ReturnedDate.HasValue).FirstOrDefault();

            if (rent is null)
            {
                return "Rent not found";
            }

            if(rent.From.Date > day.Date) 
            {
                return "Return day must be greater than the rental day";
            }

            double totalExtra = _calculatePrice.CalculatePriceExtra(rent.CarType, Utils.GetDays(rent.To, day));

            rent.Returned(day, totalExtra);

            return rent.ToString();
        }

        private static List<Rents> AddNewRents(Rents rent, List<Rents>? rents)
        {
            if (rents is null)
            {
                rents = new();
            }

            rents.Add(rent);
            return rents;
        }
    }
}
