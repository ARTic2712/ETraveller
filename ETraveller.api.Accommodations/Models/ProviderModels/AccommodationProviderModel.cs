using System;

namespace ETraveller.api.Accommodations.Models.ProviderModels
{
    public class AccommodationProviderModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public decimal Price { get; set; }
        public string Comments { get; set; }
    }
}
