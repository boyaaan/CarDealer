namespace CarDealer.Services
{
    using Models.Sales;
    using System.Collections.Generic;
    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();
        public SaleDitailsModel Details(int Id);
    }
}
