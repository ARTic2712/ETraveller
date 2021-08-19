using ETraveller.api.Accommodations.Models.ProviderModels;
using ETraveller.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETraveller.api.Accommodations.Interfaces
{
    public interface IAccommodationProvider
    {
        Task<ProviderResult<IEnumerable<AccommodationProviderModel>>> GetAllAsync();
        Task<ProviderResult<AccommodationProviderModel>> GetAsync(Guid id);
    }
}
