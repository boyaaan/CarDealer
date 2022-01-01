namespace CarDealer.Services.Models.Supplier
{
    using CarDealer.Comon.Maping;
    using Data.Models;
    public class SupplierModel : IMapFrom<Suppliers>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
