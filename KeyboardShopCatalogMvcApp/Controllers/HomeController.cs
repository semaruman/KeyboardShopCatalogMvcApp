using Microsoft.AspNetCore.Mvc;

namespace KeyboardShopCatalogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("KeyboardCatalog/Home/Index");
        }
    }
}
