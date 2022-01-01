namespace CarDealer.Web.Infrastructure.Extention
{
    using Microsoft.AspNetCore.Mvc;

    public static class ControllerExtention
    {
        public static IActionResult VeiwOrNotFound(this Controller controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }
            return controller.View(model);

        }
    }
}
