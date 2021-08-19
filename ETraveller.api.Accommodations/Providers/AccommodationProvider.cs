using AutoMapper;
using ETraveller.api.Accommodations.Data;
using ETraveller.api.Accommodations.Interfaces;
using ETraveller.api.Accommodations.Models.ProviderModels;
using ETraveller.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETraveller.api.Accommodations.Providers
{
    public class AccommodationProvider : IAccommodationProvider
    {
        private readonly AccommodationsDbContext _accommodationDbContext;
        private readonly ILogger<AccommodationProvider> _logger;
        private readonly IMapper _mapper;

        public AccommodationProvider(AccommodationsDbContext accommodationDbContext, ILogger<AccommodationProvider> logger, IMapper mapper)
        {
            _accommodationDbContext = accommodationDbContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ProviderResult<IEnumerable<AccommodationProviderModel>>> GetAllAsync()
        {
            try
            {
                var accommodations = await _accommodationDbContext.Accommodations.ToListAsync();
                if (accommodations != null && accommodations.Any())
                {
                    return new ProviderResult<IEnumerable<AccommodationProviderModel>>(true, _mapper.Map<IEnumerable<AccommodationProviderModel>>(accommodations), null);
                }
                return new ProviderResult<IEnumerable<AccommodationProviderModel>>(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<IEnumerable<AccommodationProviderModel>>(false, null, ex.Message.ToString());
            }
        }

        public async Task<ProviderResult<AccommodationProviderModel>> GetAsync(Guid id)
        {
            try
            {
                var accommodation = await _accommodationDbContext.Accommodations.FirstOrDefaultAsync(w => w.Id == id);
                if (accommodation != null)
                {
                    return new ProviderResult<AccommodationProviderModel>(true, _mapper.Map<AccommodationProviderModel>(accommodation), null);
                }
                return new ProviderResult<AccommodationProviderModel>(false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ProviderResult<AccommodationProviderModel>(false, null, ex.Message.ToString());
            }
        }
    }
}
