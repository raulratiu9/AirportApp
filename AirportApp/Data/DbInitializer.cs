using AirportApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AirportContext(serviceProvider.GetRequiredService<DbContextOptions<AirportContext>>()))
            {


                Company Company1 = new()
                {
                    Name = "Wizz Air",
                    Description = "wizzair.com"
                };

                Company Company2 = new()
                {
                    Name = "Lufthansa",
                    Description = "lufthansa.com"

                };

                Company Company3 = new()
                {
                    Name = "Emirates",
                    Description = "emirates.com"

                };


                context.Companies.AddRange(Company1, Company2, Company3);

                Flight Flight1 = new()
                {
                    Departure = "LTN",
                    DateTime = new DateTime(1706178153),
                    CompanyId = 1,
                };

                Flight Flight2 = new()
                {
                    Departure = "OTP",
                    DateTime = new DateTime(1706203353),
                    CompanyId = 1,
                };

                Flight Flight3 = new()
                {
                    Departure = "DUB",
                    DateTime = new DateTime(1706203353),
                    CompanyId = 1,
                };


                context.Flights.AddRange(Flight1, Flight2, Flight3);

                context.Gates.AddRange(
                    new Gate
                    {
                        Name = "B1"
                    },
                    new Gate
                    {
                        Name = "B2"

                    },
                    new Gate
                    {
                        Name = "C4"

                    },
                    new Gate
                    {
                        Name = "A3"

                    },
                    new Gate
                    {
                        Name = "B4"

                    },
                    new Gate
                    {
                        Name = "B8"
                    }
                );

                context.Passengers.AddRange(
                    new Passenger
                    {
                        Name = "Popescu Marcela",
                        FlightId = 2
                    },
                    new Passenger
                    {
                        Name = "Mihailescu Cornel",
                        FlightId = 1
                    }
                );

                context.Aircrafts.AddRange(
                    new Aircraft
                    {
                        Name = "Boieng 777",
                        Image = "",
                        CompanyId = 2

                    },
                    new Aircraft
                    {
                        Name = "Airbus A320",
                        Image = "",
                        CompanyId = 1
                    }
                );

                context.SaveChanges();
            }
        }
    }
}