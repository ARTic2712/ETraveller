using AutoMapper;
using ETraveller.api.Travels.Data;
using ETraveller.api.Travels.Interfaces;
using ETraveller.api.Travels.Models.ProviderModels;
using ETraveller.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETraveller.api.Travels.Providers
{
    public class TravelProvider : ITravelProvider
    {
        private readonly TravelsDbContext _travelsDbContext;
        private readonly ILogger<TravelProvider> _logger;
        private readonly IMapper _mapper;
        private readonly IFlightService _flightService;
        public TravelProvider(TravelsDbContext travelDbContext, ILogger<TravelProvider> logger, IMapper mapper, IFlightService flightService)
        {
            _travelsDbContext = travelDbContext;
            _logger = logger;
            _mapper = mapper;
            _flightService = flightService;
        }

        public async Task<ProviderResult<IEnumerable<TravelProviderModel>>> GetAllAsync()
        {
            try
            {
                var travels = await _travelsDbContext.Travels.ToListAsync();
                if(travels!=null && travels.Any())
                {
                    return new ProviderResult<IEnumerable<TravelProviderModel>>(true, _mapper.Map<IEnumerable<TravelProviderModel>>(travels), null);
                }
                return new ProviderResult<IEnumerable<TravelProviderModel>>(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<IEnumerable<TravelProviderModel>>(false, null, ex.Message.ToString());
            }
        }

        public async Task<ProviderResult<TravelProviderModel>> GetAsync(Guid id)
        {
            try
            {
                var travel = await _travelsDbContext.Travels.FirstOrDefaultAsync(w=>w.Id == id);
                if (travel != null)
                {
                    return new ProviderResult<TravelProviderModel>(true, _mapper.Map<TravelProviderModel>(travel), null);
                }
                return new ProviderResult<TravelProviderModel>(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<TravelProviderModel>(false, null, ex.Message.ToString());
            }
        }

        public Task<ProviderResult<IEnumerable<FlightModel>>> GetTravelFlightsAsync(Guid id)
        {
            return _flightService.GetFlightsAsync(id);
        }
    }
}
