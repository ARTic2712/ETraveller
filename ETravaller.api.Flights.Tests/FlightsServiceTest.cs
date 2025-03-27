using ETraveller.api.Flights.Data;
using ETraveller.api.Flights.Data.Seed;
using ETraveller.api.Flights.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ETravaller.api.Flights.Tests
{
    public class FlightsServiceTest
    {
        private IFlightProvider flightProvider;
        private FlightsDbContext dbContext;
        public FlightsServiceTest()
        {
            flightProvider = SeedFlights.GetInMemoryFlightProvider();
        }

        [Fact]
        public async Task GetFlightsWithoutSelectorAsync()
        {
            var flights = await flightProvider.GetAsync();
            Assert.True(flights.IsSuccess);
            Assert.Equal(3, flights.Data.Count());
            Assert.Null(flights.ErrorMessage);
        }        
    }
}
