using ETraveller.api.Travels.Data.Models;
using ETraveller.api.Travels.Models.ProviderModels;

namespace ETraveller.api.Travels
{
    public class TravelProfile : AutoMapper.Profile
    {
        public TravelProfile()
        {
            CreateMap<Travel, TravelProviderModel>().ReverseMap();
        }
    }
}
