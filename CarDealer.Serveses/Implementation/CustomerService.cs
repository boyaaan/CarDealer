namespace CarDealer.Services.Implementation
{
    using Data;
    using Models;
    using Models.Cars;
    using Models.Customers;
    using System;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;
        private readonly IMapper mapper;

        public CustomerService(CarDealerDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IEnumerable<CustomerModels> OrderedCustomers(OrderDirection order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Descending:
                    customersQuery = customersQuery
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c => c.Name);

                    break;
                case OrderDirection.Ascending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.Name);

                    break;

                    throw new InvalidOperationException($"Invalid order direction: {order}");
            }

            return customersQuery
                .ProjectTo<CustomerModels>(mapper.ConfigurationProvider)
                .ToList();
        }

        public CustomersTotalSalesModels TotalSalesById(int id)
        {
            return this.db
                .Customers
                .OrderByDescending(c => c.Id)
                .Where(c => c.Id == id)
                .Select(c => new CustomersTotalSalesModels
                {
                    Name = c.Name,
                    IsYoungDriver = c.IsYoungDriver,
                    BoughtCars = c.Sales.Select(s => new CarPriceModel
                    {
                        Price = s.Car.Parts.Sum(p => p.Part.Price),
                        Discount = s.Discount
                        
                    })

                })
                .FirstOrDefault();
        }
    }
}
