namespace CarDealer.Services.Models.Customers
{
    using CarDealer.Comon.Maping;
    using CarDealer.Services.Models.Cars;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomersTotalSalesModels : IMapFrom<Customers>
    {
        public string Name { get; set; }
        public bool IsYoungDriver { get; set; }
        public IEnumerable<CarPriceModel> BoughtCars { get; set; }
        public decimal TotalMoneySpent
                => this.BoughtCars
                    .Sum(c => c.Price * (1 - (decimal)c.Discount))
                    * (this.IsYoungDriver ? 0.95m : 1);

    }
}

