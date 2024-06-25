using CarRental.Entities;

namespace CarRental.Domain.Interfaces
{
    public interface ICalculatePrice
    {
        double TotalPrices(CarType typePrice, int days);
        double CalculatePriceExtra(CarType typePrice, int extraDays);
    }
}
