using Microsoft.AspNetCore.Mvc;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models;

namespace KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Controllers
{
    [Area("KeyboardCatalog")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if (model.SelectedBrand == "Все" && model.SelectedType == "Все")
            {
                return View(new IndexViewModel());
            }
            else if (model.SelectedBrand != "Все" && model.SelectedType == "Все")
            {
                KeyboardDb db = new KeyboardDb();
                model.Keyboards = db.GetKeyboardViewModels()
                    .Where(k => k.Brand == model.SelectedBrand)
                    .ToList();
                return View(model);
            }
            else if (model.SelectedBrand == "Все" && model.SelectedType != "Все")
            {
                KeyboardDb db = new KeyboardDb();
                model.Keyboards = db.GetKeyboardViewModels()
                    .Where(k => k.KeyboardType == model.SelectedType)
                    .ToList();
                return View(model);
            }
            else
            {
                KeyboardDb db = new KeyboardDb();
                model.Keyboards = db.GetKeyboardViewModels()
                    .Where(k => k.KeyboardType == model.SelectedType && k.Brand == model.SelectedBrand)
                    .ToList();
                return View(model);
            }
            //return View(model);
        }
    }
}
