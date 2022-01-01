namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Supliers;
    using Services;
    public class SuppliersController : Controller
    {
        private const string SuppliersView = "Supplier";
        private readonly ISupplierServices supliers;

        public SuppliersController(ISupplierServices supliers)
        {
            this.supliers = supliers;  
        }

        public IActionResult Local ()
             => View(SuppliersView, this.GetSuplierModel(false));
        

        public IActionResult Importer()
             => View(SuppliersView, this.GetSuplierModel(true));
        

        private SuppliersModel GetSuplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";
            var suplier = this.supliers.AllListing(importers);

            return new SuppliersModel
            {
                Type = type,
                Supliers = suplier
            };
        }
    }
}
