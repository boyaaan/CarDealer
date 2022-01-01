namespace CarDealer.Services.Models.Parts
{
    using CarDealer.Comon.Maping;
    using Data.Models;
    public class PartDetailsModel : IMapFrom<Parts>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
