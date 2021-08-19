using ETraveller.api.Flights.Data.Models;
using ETraveller.api.Flights.Models.ProviderModels;

namespace ETraveller.api.Flights
{
    public class FlightProfile : AutoMapper.Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightProviderModel>().ReverseMap();
        }
    }
}
