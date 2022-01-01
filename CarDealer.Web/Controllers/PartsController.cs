namespace CarDealer.Web.Controllers
{
    using Services;
    using Services.AllConstants;
    using Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PartsController : Controller
    {
        private readonly Constantants constPageSize;
        private readonly IPartServices parts;
        private readonly ISupplierServices supplier;

        public PartsController(IPartServices parts, ISupplierServices supplier)
        {
            this.parts = parts;
            this.supplier = supplier;

            this.constPageSize = new Constantants();
        }
        public IActionResult Create()
            => View(new PartFormModel
            {
                Suppliers = this.GetSupplierListItem()
            });

        [HttpPost]
        public IActionResult Create(PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Suppliers = this.GetSupplierListItem();
                return View(model);
            }

            this.parts.Create(
                model.Name,
                model.Price,
                model.Quantity,
                model.SupplierId);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id) => View(id);
        public IActionResult Destroy(int id)
        {
            this.parts.Delete(id);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var parts = this.parts.ById(id);

            if (parts == null)
            {
                return NotFound();
            }

            return View(new PartFormModel
            {
                Name = parts.Name,
                Price = parts.Price,
                Quantity = parts.Quantity,
                IsEdit = true
            });
        }

        [HttpPost]
        public IActionResult Edit(int id ,PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsEdit = true;
                return View(model);
            }

            this.parts.Edit(
                id,
                model.Price,
                model.Quantity);

            return RedirectToAction(nameof(All));
        }

        public IActionResult All(int page = 1)
            => View(new PartsPageListModel
            {
                Parts = this.parts.All(page),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.parts.Total() / constPageSize.PageSize)
            });

        private IEnumerable<SelectListItem> GetSupplierListItem()
            => this.supplier
                   .All()
                   .Select(s => new SelectListItem
                   {
                       Text = s.Name,
                       Value = s.Id.ToString()
                   });
    }
}
