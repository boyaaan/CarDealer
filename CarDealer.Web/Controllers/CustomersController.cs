namespace CarDealer.Web.Controllers
{
    using Infrastructure.Extention;
    using Services;
    using Models.Customers;
    using Services.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("{all}/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "ascending"
                ? OrderDirection.Ascending
                : OrderDirection.Descending;


            var customers = this.customers.OrderedCustomers(orderDirection);

            return View(new AllCustomers
            {
                Customes = customers,
                OrderDirection = orderDirection
            });
        }

        [Route("{id}")]
        public IActionResult TotalSales(int id)
          => this
            .VeiwOrNotFound(this.customers.TotalSalesById(id));
    }
}
