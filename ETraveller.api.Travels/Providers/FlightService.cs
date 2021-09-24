using ETraveller.api.Travels.Interfaces;
using ETraveller.api.Travels.Models.ProviderModels;
using ETraveller.Common.Consts;
using ETraveller.Common.Extensions;
using ETraveller.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ETraveller.api.Travels.Providers
{
    public class FlightService : IFlightService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<FlightService> _logger;
        public FlightService(IHttpClientFactory httpClientFactory, ILogger<FlightService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<ProviderResult<IEnumerable<FlightModel>>> GetFlightsAsync(Guid travelId)
        {
            try
            {
                var result = await _httpClientFactory.CreateClient(ServiceName.FlightService)
                    .GetResultAsync<IEnumerable<FlightModel>>($"/api/flights/travel/{travelId}");
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<IEnumerable<FlightModel>>(false, null, ex.Message.ToString());
            }
        }
    }
}
