using System;
using ESC2.Library.Data.SqlServer.DataProvider;
using ESC2.Module.System.Data.DataObjects.Warehouse;
using ESC2.Module.System.Data.Repos.Warehouse;

namespace ESC2.Apps.Warehouse.Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=ESC2;Trusted_Connection=True;";
            var dbProvider = new SqlServerDataProvider(connectionString);

            var periodRepo = new DayPeriodRepo(dbProvider);

            int i = 0;
            DateTime current = new DateTime(1970, 1, 1);
            DateTime max = new DateTime(2100, 12, 31);

            do
            {
                var period = new DayPeriod
                {
                    Id = i,
                    Day = current.Day,
                    Month = current.Month,
                    Year = current.Year,
                    DayOfWeek = (byte)current.DayOfWeek
                };

                periodRepo.Save(period);

                Console.WriteLine($"Saved {current.ToShortDateString()}");

                i++;
                current = current.AddDays(1);
            } while (current < max);

        }
    }
}
