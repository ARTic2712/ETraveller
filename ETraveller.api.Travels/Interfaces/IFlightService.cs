using ETraveller.api.Travels.Models.ProviderModels;
using ETraveller.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETraveller.api.Travels.Interfaces
{
    public interface IFlightService
    {
        Task<ProviderResult<IEnumerable<FlightModel>>> GetFlightsAsync(Guid travelId);
    }
}
