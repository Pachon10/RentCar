using CarRental.Data;
using CarRental.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Domain
{
    public class CalculatePrice : ICalculatePrice
    {
        private readonly Datas _data;

        //Const Premium
        private const int PORCENTAGE_PREMIUM_EXTRA_DAYS = 20;

        //Const SUV
        private const int DAY_WITHOUT_DISCOUNT_SUV = 7;
        private const int DAY_WITH_SECOND_DISCOUNT_SUV = 30;
        private const int FIRT_PORCENTAGE_DISCOUNT_SUV = 80;
        private const int SECOND_PORCENTAGE_DISCONT_SUV = 50;
        private const int PORCENTAGE_SUV_EXTRA_DAYS = 60;

        //Const Small
        private const int DAY_WITHOUT_DISCOUNT_SMALL = 7;
        private const int PORCENTAGE_DISCOUNT_SMALL = 60;
        private const int PORCENTAGE_SMALL_EXTRA_DAYS = 30;

        public CalculatePrice(Datas data)
        {
            _data = data;
        }

        public double TotalPrices(CarType typePrice, int days)
        {
            if (days <= 0)
            {
                return 0;
            }

            switch (typePrice)
            {
                case CarType.Premium:
                    return CalculatePremiumPrice(days);
                case CarType.SUV:
                    return CalculateSuvPrice(days);
                case CarType.Small:
                    return CalculateSmallPrice(days);
                default:
                    return 0;
            }
        }

        public double CalculatePriceExtra(CarType typePrice, int extraDays)
        {
            if (extraDays <= 0)
            {
                return 0;
            }

            switch (typePrice)
            {
                case CarType.Premium:
                    return CalculateExtraPremiumDays(extraDays);
                case CarType.SUV:
                    return CalculateExtraSuvDays(extraDays);
                case CarType.Small:
                    return CalculateExtraSmallDays(extraDays);
                default:
                    return 0;
            }
        }

        private double CalculatePremiumPrice(int days)
        {
            if (!_data.Prices!.TryGetValue(CarType.Premium, out var price))
            {
                return 0;
            }

            return price * days;
        }

        private double CalculateSuvPrice(int days)
        {
            double total = 0;

            if (!_data.Prices!.TryGetValue(CarType.SUV, out var price))
            {
                return total;
            }

            if (days > DAY_WITHOUT_DISCOUNT_SUV)
            {
                total = price * DAY_WITHOUT_DISCOUNT_SUV;

                if (days > DAY_WITH_SECOND_DISCOUNT_SUV)
                {
                    total += GetPricesPorcentage(price, FIRT_PORCENTAGE_DISCOUNT_SUV) * (DAY_WITH_SECOND_DISCOUNT_SUV - DAY_WITHOUT_DISCOUNT_SUV);
                    total += GetPricesPorcentage(price, SECOND_PORCENTAGE_DISCONT_SUV) * (days - DAY_WITH_SECOND_DISCOUNT_SUV);
                }
                else
                {
                    total += GetPricesPorcentage(price, FIRT_PORCENTAGE_DISCOUNT_SUV) * (days - DAY_WITHOUT_DISCOUNT_SUV);
                }
            }
            else
            {
                total = price * days;
            }

            return total;
        }

        private double CalculateSmallPrice(int days)
        {
            double total = 0;

            if (!_data.Prices!.TryGetValue(CarType.Small, out var price))
            {
                return total;
            }

            if (days > DAY_WITHOUT_DISCOUNT_SMALL)
            {
                total = price * DAY_WITHOUT_DISCOUNT_SMALL;
                total += GetPricesPorcentage(price, PORCENTAGE_DISCOUNT_SMALL) * (days - DAY_WITHOUT_DISCOUNT_SMALL);
            }
            else
            {
                total = price * days;
            }

            return total;
        }

        private double CalculateExtraPremiumDays(int days)
        {
            if (!_data.Prices!.TryGetValue(CarType.Premium, out var price))
            {
                return 0;
            }

            return (price + GetPricesPorcentage(price, PORCENTAGE_PREMIUM_EXTRA_DAYS)) * days;
        }

        private double CalculateExtraSuvDays(int days)
        {
            if (!_data.Prices!.TryGetValue(CarType.SUV, out var price) ||
                !_data.Prices!.TryGetValue(CarType.Small, out var priceSmall))
            {
                return 0;
            }

            return (price + GetPricesPorcentage(priceSmall, PORCENTAGE_SUV_EXTRA_DAYS)) * days;
        }

        private double CalculateExtraSmallDays(int days)
        {
            if (!_data.Prices!.TryGetValue(CarType.Small, out var price))
            {
                return 0;
            }

            return (price + GetPricesPorcentage(price, PORCENTAGE_SMALL_EXTRA_DAYS)) * days;
        }

        private double GetPricesPorcentage(double price, int discount)
        {
            return price / 100 * discount;
        }
    }
}
