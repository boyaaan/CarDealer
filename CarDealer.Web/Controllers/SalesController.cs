namespace CarDealer.Web.Controllers
{
    using Infrastructure.Extention;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [Route("Sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }

        [Route("")]
        public IActionResult All() 
            => View(this.sales.All());

        [Route("{Id}")]
        public IActionResult Detail(int id)
            => this.VeiwOrNotFound(this.sales.Details(id));
    }
}
