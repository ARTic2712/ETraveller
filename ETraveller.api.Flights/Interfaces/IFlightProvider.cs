using ETraveller.api.Flights.Data.Models;
using ETraveller.api.Flights.Models.ProviderModels;
using ETraveller.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETraveller.api.Flights.Interfaces
{
    public interface IFlightProvider
    {
        Task<ProviderResult<IEnumerable<FlightProviderModel>>> GetAsync(Func<Flight, bool> selector = null);
        Task<ProviderResult<FlightProviderModel>> GetAsync(Guid id);
    }
}
