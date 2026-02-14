using Microsoft.AspNetCore.Mvc;
using KeyboardShopCatalogMvcApp.Areas.Admin.Models;

namespace KeyboardShopCatalogMvcApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("{area}/[controller]/[action]")]
    public class HomeController : Controller
    {
        AdminModel adminModel = new AdminModel();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View(new AdminModel());
        }

        [HttpPost]
        public IActionResult Authorization(AdminModel admin)
        {
            if (ModelState.IsValid)
            {
                adminModel = admin;
                return RedirectToAction("SuccessAuthorization");
            }
            else
            {
                return View(admin);
            }
        }

        public IActionResult SuccessAuthorization()
        {
            return View();
        }
    }
}
