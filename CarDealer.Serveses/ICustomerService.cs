namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using Models.Customers;
    using System.Collections.Generic;
    public interface ICustomerService
    {       
        IEnumerable<CustomerModels> OrderedCustomers(OrderDirection order);

        CustomersTotalSalesModels TotalSalesById(int id);
    }
}
