using ETraveller.api.Travels.Models.ProviderModels;
using ETraveller.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETraveller.api.Travels.Interfaces
{
    public interface ITravelProvider
    {
        Task<ProviderResult<IEnumerable<TravelProviderModel>>> GetAllAsync();
        Task<ProviderResult<TravelProviderModel>> GetAsync(Guid id);
        Task<ProviderResult<IEnumerable<FlightModel>>> GetTravelFlightsAsync(Guid id);

    }
}
