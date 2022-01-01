namespace CarDealer.Web.Models.Supliers
{
    using Services.Models.Supplier;
    using System.Collections.Generic;
    public class SuppliersModel
    {
        public string Type { get; set; }
        public IEnumerable<SupplierListingModel> Supliers { get; set; }
    }
}
