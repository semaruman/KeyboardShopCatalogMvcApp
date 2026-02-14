using Microsoft.AspNetCore.Mvc;
using KeyboardShopCatalogMvcApp.Areas.KeyboardCatalog.ViewModels;

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
            return View(model);
        }
    }
}
