using CarRental.Common;

namespace CarRental.Entities
{
    public enum CarType
    {
        Premium,
        SUV,
        Small
    }

    public class Rents
    {
        public Rents(
            string carName,
            CarType carType,
            string nameUser,
            int loyaltyPoints,
            DateTime from,
            DateTime to,
            double totalPrice,
            double extraPrice)
        {
            CarName = carName;
            CarType = carType;
            NameUser = nameUser;
            LoyaltyPoints = loyaltyPoints;
            From = from;
            To = to;
            TotalPrice = totalPrice;
            ExtraPrice = extraPrice;
        }

        public string CarName { get; }
        public CarType CarType { get; }
        public string NameUser { get; }
        public int LoyaltyPoints { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public double TotalPrice { get; }
        public DateTime? ReturnedDate { get; private set; }
        public double ExtraPrice { get; private set; }

        public void Returned(DateTime returned, double extraPrice)
        {
            ReturnedDate = returned;
            ExtraPrice = extraPrice;
        }

        public override string ToString()
        {
            int totalDays = 0;
            if (ReturnedDate.HasValue)
            {
                totalDays = Utils.GetDays(To, ReturnedDate.Value);
                return $"{CarName} ({CarType}) {totalDays} extra day{(totalDays > 1 ? "s" : "")} -> {ExtraPrice}€";
            }

            totalDays = Utils.GetDays(From, To);
            return $"{CarName} ({CarType}) {Utils.GetDays(From, To)} day{(totalDays > 1 ? "s" : "")} -> {TotalPrice}€";
        }
    }
}
