namespace CarDealer.Services.Models.Parts
{
    using CarDealer.Comon.Maping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class PartListingModel : PartModel, IMapFrom<Parts>
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue)]
        public int Quantity { get; set; }
        public string SupplierName { get; set; }
    }
}
