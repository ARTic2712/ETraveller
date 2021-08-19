using ETraveller.api.Flights.Models.ProviderModels;
using ETraveller.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETraveller.api.Flights.Interfaces
{
    public interface IFlightProvider
    {
        Task<ProviderResult<IEnumerable<FlightProviderModel>>> GetAllAsync();
        Task<ProviderResult<FlightProviderModel>> GetAsync(Guid id);
    }
}
