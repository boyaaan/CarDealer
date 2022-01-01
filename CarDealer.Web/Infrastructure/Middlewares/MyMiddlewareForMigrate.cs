namespace CarDealer.Web.Infrastructure.Middlewares
{
    using CarDealer.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    public class MyMiddlewareForMigrate
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareForMigrate(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.RequestServices.GetRequiredService<CarDealerDbContext>().Database.Migrate();

            await _next(httpContext);

        }
    }
}
