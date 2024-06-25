using CarRental.Entities;

namespace CarRental.Data
{
    public static class GenerateData
    {
        public static Dictionary<string, CarType> GenerateCars() 
        {
            Dictionary<string, CarType> cars = new();

            cars.Add("BMW 7", CarType.Premium);
            cars.Add("Kia Sorento", CarType.SUV);
            cars.Add("Nissan Juke", CarType.SUV);
            cars.Add("Seat Ibiza", CarType.Small);

            return cars;
        }

        public static Dictionary<CarType, double> GeneratePrices() 
        {
            Dictionary<CarType, double> prices = new();

            prices.Add(CarType.Premium, 300);
            prices.Add(CarType.SUV, 150);
            prices.Add(CarType.Small, 50);

            return prices;
        }

        public static Dictionary<CarType, int> GenerateLoyaltyPoints()
        {
            Dictionary<CarType, int> loyalty = new();

            loyalty.Add(CarType.Premium, 5);
            loyalty.Add(CarType.SUV, 3);
            loyalty.Add(CarType.Small, 1);

            return loyalty;
        }

    }
}
