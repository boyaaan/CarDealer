namespace CarDealer.Services.Implementation
{
    using Data;
    using Models.Sales;
    using Models.Cars;
    using System.Collections.Generic;
    using System.Linq;
    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<SaleListModel> All()
        {
            var result = this.db
                .Sales
                .Select(s => new SaleListModel
                {
                    Id = s.Id,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                    IsYuongDriver = s.Customer.IsYoungDriver,

                })
                .ToList();

            return result;
        }
           

        public SaleDitailsModel Details(int Id)
            => this.db
                   .Sales
                   .OrderByDescending(s => s.Id)
                   .Where(s => s.Id == Id)
                   .Select(s => new SaleDitailsModel
                   {
                       Id = s.Id,
                       CustomerName = s.Customer.Name,
                       Price = s.Car.Parts.Sum(p => p.Part.Price),
                       IsYuongDriver = s.Customer.IsYoungDriver,
                       Car = new CarModel
                       {
                           Make = s.Car.Make,
                           Model = s.Car.Model,
                           TravelledDistance = s.Car.TravelledDistance
                       }
                   })
                   .FirstOrDefault();
    }
}
