namespace CarDealer.Services.Implementation
{
    using Data;
    using Models;
    using Models.Parts;
    using Models.Cars;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
 
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;
        private readonly IMapper mapper;

        public CarService(CarDealerDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IEnumerable<CarModel> ByMake(string make)

            => this.db
                    .Car
                    .Where(c => c.Make.ToLower() == make.ToLower())
                    .OrderBy(c => c.Model)
                    .ThenBy(c => c.TravelledDistance)
                    .ProjectTo<CarModel>(mapper.ConfigurationProvider)
                    .ToList();


        public IEnumerable<CarWithThePartsModel> WithParts()

                => this.db
                .Car
                .Select(c => new CarWithThePartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price

                    })
                })
                .ToList();
    }
}
