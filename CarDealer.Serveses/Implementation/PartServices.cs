namespace CarDealer.Services.Implementation
{
    using Data;
    using Data.Models;
    using AllConstants;
    using Models.Parts;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    public class PartServices : IPartServices
    {
        private readonly Constantants ConstPageSize;
        private readonly CarDealerDbContext db;
        private readonly IMapper mapper;

        public PartServices(CarDealerDbContext db,IMapper mapper)
        {
            this.db = db;
            this.ConstPageSize = new Constantants();
            this.mapper = mapper;
        }
        public IEnumerable<PartListingModel> All(int page = 1)
        {
            var result = db
                    .Parts
                    .OrderByDescending(p => p.Id)
                    .Skip((page - 1) * (int)ConstPageSize.PageSize)
                    .Take((int)ConstPageSize.PageSize)
                    .ProjectTo<PartListingModel>(this.mapper.ConfigurationProvider)
                    .ToList();

            return result;
        } 

        public PartDetailsModel ById(int id)
            => this.db
                   .Parts
                   .Where(p => p.Id == id)
                   .ProjectTo<PartDetailsModel>(this.mapper.ConfigurationProvider)
                   .FirstOrDefault();

        public void Create(string name, decimal price, int quantity, int supplierId)
        {
            var part = new Parts
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity : 1,
                SupplierId = supplierId
            };

            this.db.Add(part);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, decimal price, int quantity)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Price = price;
            part.Quantity = quantity;

            this.db.SaveChanges();
        }

        public int Total() => this.db.Parts.Count();

    }
}
