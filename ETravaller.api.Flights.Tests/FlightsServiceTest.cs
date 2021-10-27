using AutoMapper;
using ETraveller.api.Flights;
using ETraveller.api.Flights.Data;
using ETraveller.api.Flights.Data.Models;
using ETraveller.api.Flights.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ETravaller.api.Flights.Tests
{
    public class FlightsServiceTest
    {
        private FlightProvider flightProvider;
        private FlightsDbContext dbContext;
        public FlightsServiceTest()
        {
            var options = new DbContextOptionsBuilder<FlightsDbContext>()
                .UseInMemoryDatabase(nameof(FlightsServiceTest)).Options;
            dbContext = new FlightsDbContext(options);
            CreateFlights();
            var flightProfile = new FlightProfile();
            var mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(flightProfile)));
            flightProvider = new FlightProvider(dbContext, null, mapper);
        }

        [Fact]
        public async Task GetFlightsWithoutSelectorAsync()
        {
            var flights = await flightProvider.GetAsync();
            Assert.True(flights.IsSuccess);
            Assert.Equal(3, flights.Data.Count());
            Assert.Null(flights.ErrorMessage);
        }



        private void CreateFlights()
        {
            dbContext.AddRange(
                new List<Flight>
                {
                    new Flight
                    {
                        Id = new Guid("e42acab7-e602-4199-88d0-99ee642736dd"),
                        TravelId = new Guid("24021ff7-d8c7-4003-800e-e087288c71f5"),
                        Departure = "Moscow",
                        DepartureTime = new DateTime(2021,11,23,07,55,0),
                        Arrival = "Cancun",
                        ArrivalTime = new DateTime(2021,11,23,14,10,0),
                        FlightClass = ETraveller.Common.Enum.FlightClass.Econom,
                        PassengerCount = 3,
                        Price = 890
                    },
                    new Flight
                    {
                        Id = new Guid("539617a7-4f5d-47c5-afa2-72a536e8fb65"),
                        TravelId = new Guid("24021ff7-d8c7-4003-800e-e087288c71f5"),
                        Departure = "Cancun",
                        DepartureTime = new DateTime(2021,12,02,16,43,0),
                        Arrival = "Moscow",
                        ArrivalTime = new DateTime(2021,12,03,11,55,0),
                        FlightClass = ETraveller.Common.Enum.FlightClass.PremiumEconomy,
                        PassengerCount = 3,
                        Price = 1220
                    },
                    new Flight
                    {
                        Id = new Guid("1efe8714-4c16-4f01-993c-4f87119f0c55"),
                        TravelId = new Guid("0ea44a7d-779e-4c5f-b8d7-0d4c5c394725"),
                        Departure = "Philadelphia",
                        DepartureTime = new DateTime(2021,11,23,06,25,0),
                        Arrival = "Cancun",
                        ArrivalTime = new DateTime(2021,11,23,11,23,0),
                        FlightClass = ETraveller.Common.Enum.FlightClass.Econom,
                        PassengerCount = 2,
                        Price = 230
                    },
                }                
            );

            dbContext.SaveChanges();
        }
    }
}
