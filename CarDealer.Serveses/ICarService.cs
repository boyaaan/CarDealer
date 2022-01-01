namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models;
    using Models.Cars;
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);
        IEnumerable<CarWithThePartsModel> WithParts ();
    }
}
