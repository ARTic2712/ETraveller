using AutoMapper;
using ETraveller.api.Flights.Data;
using ETraveller.api.Flights.Data.Models;
using ETraveller.api.Flights.Interfaces;
using ETraveller.api.Flights.Models.ProviderModels;
using ETraveller.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETraveller.api.Flights.Providers
{
    public class FlightProvider : IFlightProvider
    {
        private readonly FlightsDbContext _flightsDbContext;
        private readonly ILogger<FlightProvider> _logger;
        private readonly IMapper _mapper;

        public FlightProvider(FlightsDbContext flightsDbContext, ILogger<FlightProvider> logger, IMapper mapper)
        {
            _flightsDbContext = flightsDbContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ProviderResult<IEnumerable<FlightProviderModel>>> GetAsync(Func<Flight,bool> selector = null)
        {
            try
            {
                var flights = selector == null ? await _flightsDbContext.Flights.ToListAsync() : _flightsDbContext.Flights.Where(selector).ToList();
                if (flights != null && flights.Any())
                {
                    return new ProviderResult<IEnumerable<FlightProviderModel>>(true, _mapper.Map<IEnumerable<FlightProviderModel>>(flights), null);
                }
                return new ProviderResult<IEnumerable<FlightProviderModel>>(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<IEnumerable<FlightProviderModel>>(false, null, ex.Message.ToString());
            }
        }

        public async Task<ProviderResult<FlightProviderModel>> GetAsync(Guid id)
        {
            try
            {
                var flight = await _flightsDbContext.Flights.FirstOrDefaultAsync(w => w.Id == id);
                if (flight != null)
                {
                    return new ProviderResult<FlightProviderModel>(true, _mapper.Map<FlightProviderModel>(flight), null);
                }
                return new ProviderResult<FlightProviderModel>(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<FlightProviderModel>(false, null, ex.Message.ToString());
            }
        }     
    }
}
