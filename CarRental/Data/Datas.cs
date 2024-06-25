using CarRental.Entities;

namespace CarRental.Data
{
    public class Datas
    {
        private static Dictionary<CarType, double>? _prices = new();
        private static Dictionary<CarType, int>? _loyaltyPoints = new();
        private static Dictionary<string, CarType>? _cars = new();
        private static Dictionary<string, List<Rents>>? _rents = new();

        public Datas()
        {
            Prices = GenerateData.GeneratePrices();
            Cars = GenerateData.GenerateCars();
            LoyaltyPoints = GenerateData.GenerateLoyaltyPoints();
        }

        public Dictionary<CarType, int>? LoyaltyPoints
        {
            get => _loyaltyPoints;
            private set
            {
                if (value is null)
                {
                    _loyaltyPoints = new();
                }
                else
                {
                    _loyaltyPoints = value;
                }
            }
        }

        public Dictionary<CarType, double>? Prices
        {
            get => _prices;
            private set
            {
                if (value is null)
                {
                    _prices = new();
                }
                else
                {
                    _prices = value;
                }
            }
        }

        public Dictionary<string, CarType>? Cars
        {
            get => _cars;
            private set
            {
                if (value is null)
                {
                    _cars = new();
                }
                else
                {
                    _cars = value;
                }
            }
        }
        public Dictionary<string,List<Rents>>? Rents
        {
            get => _rents;
            private set
            {
                if (value is null)
                {
                    _rents = new();
                }
                else
                {
                    _rents = value;
                }
            }
        }
    }
}
