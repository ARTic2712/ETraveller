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
        public TravelProvider(TravelsDbContext travelDbContext, ILogger<TravelProvider> logger, IMapper mapper)
        {
            _travelsDbContext = travelDbContext;
            _logger = logger;
            _mapper = mapper;
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
    }
}
