namespace CarDealer.Web.Controllers
{
    using Models.Çars;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    
    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        [Route("{make}", Order = 2)]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }

        [Route("parts", Order = 1)]
        public IActionResult Parts()
           => View(this.cars.WithParts());
        
    }
}
