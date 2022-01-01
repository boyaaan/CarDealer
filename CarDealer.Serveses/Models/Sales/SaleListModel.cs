namespace CarDealer.Services.Models.Sales
{
    public class SaleListModel : SaleModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public bool IsYuongDriver { get; set; }

        public decimal DescontedPrice => 
            this.Price * (1 - (this.Discount + (this.IsYuongDriver ? 0.05m : 0)));

    }
}
