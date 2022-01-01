namespace CarDealer.Web.Models.Customers
{
    using Services.Models.Customers;
    using Services.Models;
    using System.Collections.Generic;
    public class AllCustomers
    {
        public IEnumerable<CustomerModels> Customes { get; set; }
        public OrderDirection OrderDirection { get; set; }
    }
}
