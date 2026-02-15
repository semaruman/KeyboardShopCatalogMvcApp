using Microsoft.AspNetCore.Mvc;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            KeyboardDb db = new KeyboardDb();
            model.Keyboards = db.GetKeyboardViewModels();

            // фильтрация

            if (model.SelectedBrand != "Все")
            {
                
                model.Keyboards = model.Keyboards
                    .Where(k => k.Brand == model.SelectedBrand)
                    .ToList();
            }

            if (model.SelectedType != "Все")
            {
                model.Keyboards = model.Keyboards
                    .Where(k => k.KeyboardType == model.SelectedType)
                    .ToList();
            }

            // сортировка
            if (model.SortType == "None")
            {
                // никак не сортирую
            }
            else if (model.SortType == "PriceAsc")
            {
                model.Keyboards =  model.Keyboards.OrderBy(k => k.Price).ToList();
            }
            else if (model.SortType == "PriceDesc")
            {
                model.Keyboards = model.Keyboards.OrderByDescending(k => k.Price).ToList();
            }
            return View(model);
        }
    }
}
