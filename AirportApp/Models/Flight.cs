namespace AirportApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public DateTime DateTime { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        public int GateId { get; set; }
        public Company? Company { get; set; }
        public Gate? Gate { get; set; }
    }
}
