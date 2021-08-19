using ETraveller.Common.Enum;
using System;

namespace ETraveller.api.Flights.Data.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public Guid TravelId { get; set; }


        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }

        public string Arrival { get; set; }
        public DateTime ArrivalTime { get; set; }

        public short PassengerCount { get; set; }
        public decimal Price { get; set; }

        public FlightClass FlightClass { get; set; }
    }
}
