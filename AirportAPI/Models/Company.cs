﻿namespace AirportAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Flight>? Flights { get; set; }
        public ICollection<Aircraft>? Aircrafts { get; set; }
    }
}
