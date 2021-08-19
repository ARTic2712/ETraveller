using ETraveller.Common.Enums;
using System;

namespace ETraveller.api.Travels.Models.ProviderModels
{
    public class TravelProviderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
        public TravelType Type { get; set; }
    }
}
