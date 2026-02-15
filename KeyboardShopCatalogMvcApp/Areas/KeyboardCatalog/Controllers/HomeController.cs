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
            //фильтрация
            if (model.SelectedBrand == "Все" && model.SelectedType == "Все")
            {
                // ничего не делает, чтобы дойти до сортировки
            }
            else if (model.SelectedBrand != "Все" && model.SelectedType == "Все")
            {
                KeyboardDb db = new KeyboardDb();
                model.Keyboards = db.GetKeyboardViewModels()
                    .Where(k => k.Brand == model.SelectedBrand)
                    .ToList();
            }
            else if (model.SelectedBrand == "Все" && model.SelectedType != "Все")
            {
                KeyboardDb db = new KeyboardDb();
                model.Keyboards = db.GetKeyboardViewModels()
                    .Where(k => k.KeyboardType == model.SelectedType)
                    .ToList();
            }
            else
            {
                KeyboardDb db = new KeyboardDb();
                model.Keyboards = db.GetKeyboardViewModels()
                    .Where(k => k.KeyboardType == model.SelectedType && k.Brand == model.SelectedBrand)
                    .ToList();
            }
            Console.WriteLine(model.SortType);
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
