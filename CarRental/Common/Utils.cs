namespace CarRental.Common
{
    public static class Utils
    {
        public static int GetDays(DateTime from, DateTime to)
        {
            int days = 0;
            if (from.Date < to.Date)
            {
                var totalDays = (to.Date - from.Date).TotalDays;
                days = Convert.ToInt32(totalDays);
            }

            return days;
        }
    }
}
