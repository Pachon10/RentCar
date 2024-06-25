namespace CarRental.Domain.Interfaces
{
    public interface IRent
    {
        string CreateRent(
            string carName,
            string nameUser,
            DateTime from,
            DateTime to);

        string ReturnedCar(
            string carName,
            string nameUser,
            DateTime day);
    }
}
