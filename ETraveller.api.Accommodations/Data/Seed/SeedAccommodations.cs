using AutoMapper;
using ETraveller.api.Accommodations.Data.Models;
using ETraveller.api.Accommodations.Interfaces;
using ETraveller.api.Accommodations.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ETraveller.api.Accommodations.Data.Seed
{
    internal static class SeedAccommodations
    {
        internal static IAccommodationProvider GetInMemoryAccommodationProvider()
        {
            var options = new DbContextOptionsBuilder<AccommodationsDbContext>()
                .UseInMemoryDatabase(nameof(AccommodationsDbContext)).Options;
            var dbContext = CreateAccommodations(options);
            var accommodationProfile = new AccommodationProfile();
            var mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(accommodationProfile)));
            return new AccommodationProvider(dbContext, null, mapper);
        }

        private static AccommodationsDbContext CreateAccommodations(DbContextOptions<AccommodationsDbContext> options)
        {
            var dbContext = new AccommodationsDbContext(options);
            dbContext.Database.EnsureDeleted();

            dbContext.AddRange(
                new List<Accommodation>
                {
                    new Accommodation
                    {
                        Id = new Guid("e42acab7-e602-4199-88d0-99ee642736dd"),
                        TravelId = new Guid("24021ff7-d8c7-4003-800e-e087288c71f5"),
                        Name = "Hilton",
                        Adress = "1100 Main St,Dallas,TX",
                        CheckIn = new DateTime(2025,01,23,14,10,0),
                        CheckOut = new DateTime(2025,01,25,14,10,0),
                        Price = 134.05M,
                        Comments = "Comment  1"
                    },
                    new Accommodation
                    {
                        Id = new Guid("539617a7-4f5d-47c5-afa2-72a536e8fb65"),
                        TravelId = new Guid("24021ff7-d8c7-4003-800e-e087288c71f5"),
                        Name = "Holliday Inn",
                        Adress = "1200 Broad St,Dallas,TX",
                        CheckIn = new DateTime(2025,02,23,14,10,0),
                        CheckOut = new DateTime(2025,02,25,14,10,0),
                        Price = 72.05M,
                        Comments = "Comment  2"
                    },
                    new Accommodation
                    {
                        Id = new Guid("1efe8714-4c16-4f01-993c-4f87119f0c55"),
                        TravelId = new Guid("0ea44a7d-779e-4c5f-b8d7-0d4c5c394725"),
                        Name = "Dallas Inn",
                        Adress = "1302 First St,Dallas,TX",
                        CheckIn = new DateTime(2025,03,23,14,10,0),
                        CheckOut = new DateTime(2025,03,25,14,10,0),
                        Price = 242.05M,
                        Comments = "Comment  3"
                    },
                }
            );

            dbContext.SaveChanges();
            return dbContext;
        }
    }
}
