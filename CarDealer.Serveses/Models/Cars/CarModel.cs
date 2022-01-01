namespace CarDealer.Services.Models.Cars
{
    using Data.Models;
    using CarDealer.Comon.Maping;

    public class CarModel : IMapFrom<Cars>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
    }
}
