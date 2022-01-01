namespace CarDealer.Services.Implementation
{
    using Data;
    using Models.Supplier;
    using System.Collections.Generic;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class SupplierServices : ISupplierServices
    {
        private readonly CarDealerDbContext db;
        private readonly Mapper mapper;

        public SupplierServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All()
             => this.db
                    .Suppliers
                    .OrderBy(s => s.Name)
                    .ProjectTo<SupplierModel>(mapper.ConfigurationProvider)
                    .ToList();
        
        public IEnumerable<SupplierListingModel> AllListing(bool isImporter)
            => this.db
            .Suppliers
            .Where(s => s.IsImporter == isImporter)
            .ProjectTo<SupplierListingModel>(mapper.ConfigurationProvider)
            .ToList();
    }
}
