using AutoMapper;
using ETraveller.api.Flights.Data.Models;
using ETraveller.api.Flights.Interfaces;
using ETraveller.api.Flights.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ETraveller.api.Flights.Data.Seed
{
    public static class SeedFlights
    {
        public static IFlightProvider GetInMemoryFlightProvider()
        {
            var options = new DbContextOptionsBuilder<FlightsDbContext>()
                .UseInMemoryDatabase(nameof(FlightsDbContext)).Options;
            var dbContext = CreateFlights(options);
            var flightProfile = new FlightProfile();
            var mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(flightProfile)));
            return new FlightProvider(dbContext, null, mapper);
        }
        private static FlightsDbContext CreateFlights(DbContextOptions<FlightsDbContext> options)
        {
            var dbContext = new FlightsDbContext(options);
            dbContext.Database.EnsureDeleted();

            dbContext.AddRange(
                new List<Flight>
                {
                    new Flight
                    {
                        Id = new Guid("e42acab7-e602-4199-88d0-99ee642736dd"),
                        TravelId = new Guid("e42acab7-e602-4199-88d0-99ee642736dd"),
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
                        TravelId = new Guid("e42acab7-e602-4199-88d0-99ee642736dd"),
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
                        TravelId = new Guid("539617a7-4f5d-47c5-afa2-72a536e8fb65"),
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
            return dbContext;
        }
    }
}
