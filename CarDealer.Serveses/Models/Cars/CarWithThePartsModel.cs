namespace CarDealer.Services.Models
{
    using Cars;
    using Parts;
    using System.Collections.Generic;
    public class CarWithThePartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
