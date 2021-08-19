using System;

namespace ETraveller.api.Accommodations.Data.Models
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public Guid TravelId { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public decimal Price { get; set; }
        public string Comments { get; set; }
    }
}
