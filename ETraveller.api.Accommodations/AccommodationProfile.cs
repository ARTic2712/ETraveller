using ETraveller.api.Accommodations.Data.Models;
using ETraveller.api.Accommodations.Models.ProviderModels;

namespace ETraveller.api.Accommodations
{
    public class AccommodationProfile : AutoMapper.Profile
    {
        public AccommodationProfile()
        {
            CreateMap<Accommodation, AccommodationProviderModel>().ReverseMap();
        }
    }
}
