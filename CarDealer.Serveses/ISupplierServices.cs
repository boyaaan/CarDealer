namespace CarDealer.Services
{
    using Models.Supplier;
    using System.Collections.Generic;
    public interface ISupplierServices
    {
        IEnumerable<SupplierListingModel> AllListing(bool isImporter);
        IEnumerable<SupplierModel> All();
    }
}
