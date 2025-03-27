using AutoMapper;
using ETraveller.api.Travels.Interfaces;
using ETraveller.api.Travels.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using ETraveller.api.Travels.Data.Models;

namespace ETraveller.api.Travels.Data.Seed
{
    internal static class SeedTravels
    {
        public static ITravelProvider GetInMemoryTravelProvider(IFlightService flightService)
        {
            var options = new DbContextOptionsBuilder<TravelsDbContext>()
                .UseInMemoryDatabase(nameof(TravelsDbContext)).Options;
            var dbContext = CreateTravels(options);
            var travelProfile = new TravelProfile();
            var mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(travelProfile)));
            return new TravelProvider(dbContext, null, mapper, flightService);
        }

        private static TravelsDbContext CreateTravels(DbContextOptions<TravelsDbContext> options)
        {
            var dbContext = new TravelsDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.AddRange(
                new List<Travel>
                {
                    new Travel
                    {
                        Id = new Guid("e42acab7-e602-4199-88d0-99ee642736dd"),
                        UserId = new Guid("63f41ac6-70e6-4914-a489-2c0d807fe199"),
                        Name = "Travel 1",
                        Type = Common.Enums.TravelType.Vacation
                    },
                    new Travel
                    {
                        Id = new Guid("539617a7-4f5d-47c5-afa2-72a536e8fb65"),
                        UserId = new Guid("25213cca-02ca-4014-a339-47082ca91be2"),
                        Name = "Travel 2",
                        Type = Common.Enums.TravelType.Work
                    }
                }
            );

            dbContext.SaveChanges();
            return dbContext;
        }
    }
}
