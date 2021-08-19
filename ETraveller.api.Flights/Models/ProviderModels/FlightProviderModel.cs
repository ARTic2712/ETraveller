using ETraveller.api.Flights.Models.Enum;
using System;

namespace ETraveller.api.Flights.Models.ProviderModels
{
    public class FlightProviderModel
    {
        public Guid Id { get; set; }

        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }

        public string Arrival { get; set; }
        public DateTime ArrivalTime { get; set; }

        public short PassengerCount { get; set; }
        public double Price { get; set; }

        public FlightClass FlightClass { get; set; }
    }
}
