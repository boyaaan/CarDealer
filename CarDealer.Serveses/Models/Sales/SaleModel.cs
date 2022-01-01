namespace CarDealer.Services.Models.Sales
{
    using CarDealer.Comon.Maping;
    using Data.Models;
    public class SaleModel: IMapFrom<Sales>
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
