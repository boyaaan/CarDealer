 namespace CarDealer.Services
{
    using Models.Parts;
    using System.Collections.Generic;
    public interface IPartServices
    {
        IEnumerable<PartListingModel> All(int page = 1);
        PartDetailsModel ById(int id);
        void Delete(int id);
        void Edit(int id, decimal price, int quantity);
        int Total();
        void Create(string name, decimal price, int quantity, int supplierId);
    }
}
