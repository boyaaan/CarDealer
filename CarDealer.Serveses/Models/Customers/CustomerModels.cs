namespace CarDealer.Services.Models.Customers
{
    using CarDealer.Comon.Maping;
    using Data.Models;
    using System;
    public class CustomerModels : IMapFrom<Customers>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
    }
}
