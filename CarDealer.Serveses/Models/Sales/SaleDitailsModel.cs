namespace CarDealer.Services.Models.Sales
{
    using Cars;
    public class SaleDitailsModel : SaleListModel
    {
        public CarModel Car { get; set; }
    }
}
