using ETraveller.api.Travels.Models.Enums;
using System;

namespace ETraveller.api.Travels.Data.Models
{
    public class Travel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TravelType Type { get; set; }
    }
}
